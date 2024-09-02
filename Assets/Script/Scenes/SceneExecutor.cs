using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

internal static class SceneExecutor
{
    private static string targetScena;
    private static AsyncOperation done;
    private static TaskCompletionSource<bool> tsk;
    public async static Task<bool> NextScene(string sceneToLoad, string targetScene)
    {
        targetScena = targetScene;
        tsk = new TaskCompletionSource<bool>();
        tsk.SetResult(LoadScene(sceneToLoad));
        return await tsk.Task;
    }
    public async static Task<bool> BackScene(string sceneToLoad, string targetScene)
    {
        targetScena = targetScene;
        tsk = new TaskCompletionSource<bool>();
        tsk.SetResult(LoadScene(sceneToLoad));
        return await tsk.Task;
    }
    public async static Task<bool> TargetScene()
    {
        tsk = new TaskCompletionSource<bool>();
        tsk.SetResult(LoadScene(targetScena));
        return await tsk.Task;
    }
    private static bool LoadScene(string sceneToLoad)
    {
        done= SceneManager.LoadSceneAsync(sceneToLoad);
        return done.isDone;
    }
}

