# Terminal.Gui Repository Integration

To enable automatic template publishing when Terminal.Gui v2 releases are published, the Terminal.Gui repository needs to send a `repository_dispatch` event to this repository.

## Required Changes to Terminal.Gui

Add a step to the Terminal.Gui publish workflow (`.github/workflows/publish.yml`) to trigger the template repository after a successful publish to NuGet.

### Option 1: Add to existing publish workflow

Add this step at the end of the `publish` job in `.github/workflows/publish.yml`:

```yaml
- name: Trigger template repository update
  if: github.ref == 'refs/heads/v2_release'
  run: |
    curl -X POST \
      -H "Accept: application/vnd.github+json" \
      -H "Authorization: Bearer ${{ secrets.TEMPLATE_REPO_TOKEN }}" \
      -H "X-GitHub-Api-Version: 2022-11-28" \
      https://api.github.com/repos/gui-cs/Terminal.Gui.templates/dispatches \
      -d '{"event_type":"terminal-gui-v2-released","client_payload":{"version":"${{ steps.gitversion.outputs.SemVer }}"}}'
```

### Option 2: Use GitHub's repository_dispatch action

Alternatively, use the official action:

```yaml
- name: Trigger template repository update
  if: github.ref == 'refs/heads/v2_release'
  uses: peter-evans/repository-dispatch@v3
  with:
    token: ${{ secrets.TEMPLATE_REPO_TOKEN }}
    repository: gui-cs/Terminal.Gui.templates
    event-type: terminal-gui-v2-released
    client-payload: '{"version": "${{ steps.gitversion.outputs.SemVer }}"}'
```

## Required Secret

Create a Personal Access Token (PAT) or use a GitHub App token with the following permissions:
- Repository: `gui-cs/Terminal.Gui.templates`
- Permission: `contents: write` or `repository_dispatch`

Add this token as a secret named `TEMPLATE_REPO_TOKEN` in the Terminal.Gui repository settings.

## How It Works

1. When Terminal.Gui publishes to the `v2_release` branch, the publish workflow completes
2. The added step sends a `repository_dispatch` event to this repository
3. The `auto-publish.yml` workflow in this repository is triggered
4. After waiting 15 minutes for NuGet indexing, it:
   - Queries NuGet for the latest alpha/beta version
   - Updates template files with the new version
   - Creates and pushes a tag
   - The tag triggers the build workflow to publish to NuGet

## Testing

To test the integration without waiting for a real release:

1. In this repository, go to Actions → "Auto-publish on Terminal.Gui release" → Run workflow
2. Check the "Skip the 15-minute delay" option for faster testing
3. Verify that the workflow completes successfully

## Fallback

If the automatic trigger fails, templates can still be published manually as documented in `PUBLISH.md`.
