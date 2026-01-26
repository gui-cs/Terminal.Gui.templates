# Publishing Terminal.Gui.templates

## How It Works

The publishing process is automated through two GitHub Actions workflows:

### Automatic Publishing (`.github/workflows/auto-publish.yml`)

When Terminal.Gui publishes a new v2 release to the `v2_release` branch:

1. Terminal.Gui sends a `repository_dispatch` event to this repository
2. The workflow waits 15 minutes for NuGet to index the new package
3. It fetches the latest `alpha` or `beta` version of Terminal.Gui from NuGet
4. Updates the package references in template files
5. Creates and pushes a git tag (e.g., `v2.0.0-alpha.100`)
6. The tag push triggers the build workflow to publish to NuGet

### Manual Publishing

You can also manually trigger a template publish:

1. **Using the GitHub Actions UI**: Go to Actions → "Auto-publish on Terminal.Gui release" → Run workflow
   - You can optionally skip the 15-minute delay for testing

2. **Using the traditional tag method**:

```bash
# 1. Ensure you're on the main branch with latest changes
git checkout main
git pull

# 2. Commit any pending changes (if any)
git add .
git commit -m "Update for Terminal.Gui release"

# 3. Create and push a tag (triggers NuGet publish)
git tag v<version>
git push origin main
git push origin v<version>
```

The tag name (e.g., `v2.0.0-alpha.100`) is just a trigger - the actual package version will be set automatically to match the latest Terminal.Gui alpha or beta version.

### Build Workflow (`.github/workflows/build.yml`)

1. **On every push**: The workflow fetches the latest `alpha` or `beta` version of Terminal.Gui from NuGet and updates the package references
2. **On tagged pushes**: If the push includes a tag starting with `v`, the package is published to NuGet

## Changing the Pre-release Channel

The workflows currently track both `alpha` and `beta` releases. To track different pre-release channels, edit the grep pattern in both workflows:

```yaml
# Current: alpha and beta
grep -E -- '-(alpha|beta)\.'

# Example: develop only
grep -E -- '-develop\.'

# Example: multiple channels (first match wins by build number)
grep -E -- '-(alpha|rc|beta)\.'
```

## Requirements

- The `NUGET_KEY` secret must be configured in the repository settings
- Tags must start with `v` to trigger the publish step
- For automatic publishing, Terminal.Gui must send a `repository_dispatch` event with type `terminal-gui-v2-released` when publishing to the `v2_release` branch

## Verifying the Publish

After a tag is created (automatically or manually):

1. Check the [Actions tab](../../actions) for workflow status
2. Verify the package on [NuGet](https://www.nuget.org/packages/Terminal.gui.templates/)
