using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

internal class ExecutorSwithScene : ISwithScene
{
    private string nextScene;
    private string backScene;
    private TaskCompletionSource<object> tsk;
    private bool isRun = true;
    private static AsyncOperation done;
    internal ExecutorSwithScene(string nextScene, string backScene)
    {
        this.nextScene = nextScene;
        this.backScene = backScene;
    }
    public async Task<object> BackScene()
    {
        tsk.SetResult(await SwithScene(backScene));
        return await tsk.Task;
    }

    public async Task<object> NextScene()
    {
        tsk.SetResult(await SwithScene(nextScene));
        return await tsk.Task;
    }
    private async Task<object> SwithScene(string nameScene)
    {
        tsk = new TaskCompletionSource<object>();
        done = new AsyncOperation();
        int t = 0;
        //while (isRun)
        //{
        //Debug.Log(done.isDone);
            t++;
            if (t >= 101)
            {
                isRun = false;
                t =100;

                done = SceneManager.LoadSceneAsync(nameScene);
            Debug.Log(done.isDone);
            if (!done.isDone)
                {
                    isRun = true;
                }
            }
        //}
        tsk.SetResult(!isRun);
        return await tsk.Task;
    }
}

