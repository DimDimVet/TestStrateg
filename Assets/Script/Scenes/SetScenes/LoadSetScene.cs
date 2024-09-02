using System.Threading.Tasks;
using UnityEngine;

internal class LoadSetScene : SceneWrapper
{
    protected async override void SetStart()
    {
        await onIteration?.Invoke();
        Debug.Log("stop");
        bool isTemp=await StartTargetScene();
        if (!isTemp) { await onIteration?.Invoke(); }
    }
    private async Task<bool> StartTargetScene()
    {
      return await SceneExecutor.TargetScene();
    }
}

