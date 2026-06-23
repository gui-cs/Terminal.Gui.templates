#!/usr/bin/env bash
#
# Compile the C# code blocks in a generated project's AGENTS.md so the embedded agent
# guidance can't rot. If the "canonical app" snippet stops compiling against the Terminal.Gui
# the template ships, this fails — mirroring Terminal.Gui's own validate-doc-snippets approach.
#
# Usage: scripts/test-doc-snippets.sh <generated-project-dir>
set -euo pipefail

proj_dir="${1:?usage: test-doc-snippets.sh <generated-project-dir>}"
agents="$proj_dir/AGENTS.md"
[ -f "$agents" ] || { echo "::error::No AGENTS.md in $proj_dir"; exit 1; }

# The Terminal.Gui version the template targets (read from the generated app csproj).
tg_version=$(grep -hoE 'Terminal\.Gui" Version="[^"]+"' "$proj_dir"/*.csproj | head -1 | sed -E 's/.*Version="([^"]+)".*/\1/')
[ -n "$tg_version" ] || { echo "::error::Could not find the Terminal.Gui version in $proj_dir"; exit 1; }

work="$(mktemp -d)"
trap 'rm -rf "$work"' EXIT

# Split the AGENTS.md ```csharp fenced blocks into separate files.
awk -v dir="$work" '
  /^```csharp$/ { n++; f=1; file=sprintf("%s/snip-%d.cs", dir, n); next }
  /^```/        { f=0; next }
  f             { print > file }
' "$agents"

shopt -s nullglob
count=0
for snip in "$work"/snip-*.cs; do
  # Only the full-program snippets (the canonical app) compile standalone; the v1->v2
  # correction fragments are intentionally partial, so skip anything without an app entry point.
  grep -q "Application.Create" "$snip" || { echo "skip (fragment): $(basename "$snip")"; continue; }

  count=$((count + 1))
  pdir="$work/p$count"
  mkdir -p "$pdir"
  cp "$snip" "$pdir/Program.cs"
  cat > "$pdir/snippet.csproj" <<CSPROJ
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Terminal.Gui" Version="$tg_version" />
  </ItemGroup>
</Project>
CSPROJ

  echo "::group::compile AGENTS.md snippet #$count (Terminal.Gui $tg_version)"
  dotnet build "$pdir" -v quiet
  echo "::endgroup::"
done

[ "$count" -gt 0 ] || { echo "::error::No compilable C# snippet found in AGENTS.md (expected the canonical app)."; exit 1; }
echo "Compiled $count AGENTS.md snippet(s) against Terminal.Gui $tg_version — OK."
