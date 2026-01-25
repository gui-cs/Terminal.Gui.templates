# Publishing Terminal.Gui.templates

## How It Works

The GitHub Actions workflow (`.github/workflows/build.yml`) automates the publishing process:

1. **On every push**: The workflow fetches the latest `alpha` version of Terminal.Gui from NuGet and updates the package references
2. **On tagged pushes**: If the push includes a tag starting with `v`, the package is published to NuGet

## Publishing a New Version

When a new Terminal.Gui alpha is released and you want to publish an updated template:

```bash
# 1. Ensure you're on the main branch with latest changes
git checkout main
git pull

# 2. Commit any pending changes (if any)
git add .
git commit -m "Update for Terminal.Gui alpha"

# 3. Create and push a tag (triggers NuGet publish)
git tag v<version>
git push origin main
git push origin v<version>
```

The tag name (e.g., `v2.0.0-alpha.100`) is just a trigger - the actual package version will be set automatically to match the latest Terminal.Gui alpha version.

## Example

If the latest Terminal.Gui alpha is `2.0.0-alpha.100`:

```bash
git tag v2.0.0-alpha.100
git push origin main
git push origin v2.0.0-alpha.100
```

This will publish `Terminal.gui.templates` version `2.0.0-alpha.100` to NuGet.

## Changing the Pre-release Channel

To track a different pre-release channel (e.g., `develop`, `rc`, `beta`), edit the grep pattern in `.github/workflows/build.yml`:

```yaml
# Current: alpha only
grep -E -- '-alpha\.'

# Example: develop only
grep -E -- '-develop\.'

# Example: multiple channels (first match wins by build number)
grep -E -- '-(alpha|rc)\.'
```

## Requirements

- The `NUGET_KEY` secret must be configured in the repository settings
- Tags must start with `v` to trigger the publish step

## Verifying the Publish

After pushing a tag:

1. Check the [Actions tab](../../actions) for workflow status
2. Verify the package on [NuGet](https://www.nuget.org/packages/Terminal.gui.templates/)
