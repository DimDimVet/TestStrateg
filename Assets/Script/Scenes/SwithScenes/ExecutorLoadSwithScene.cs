using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;


internal class ExecutorLoadSwithScene : MonoBehaviour, ISwithScene
{
    private string nextScene;
    private string backScene;
    private string loadScene;
    private TaskCompletionSource<object> tsk;
    private AsyncOperation done;
    internal ExecutorLoadSwithScene(string loadScene, string nextScene, string backScene)
    {
        this.nextScene = nextScene;
        this.backScene = backScene;
        this.loadScene = loadScene;
    }
    public async Task<object> BackScene()
    {
        tsk = new TaskCompletionSource<object>();
        SwithScene(backScene);
        tsk.SetResult(null);
        return await tsk.Task;
    }

    public async Task<object> NextScene()
    {
        tsk = new TaskCompletionSource<object>();
        SwithScene(nextScene);
        tsk.SetResult(null);
        return await tsk.Task;
    }
    private void SwithScene(string nameScene)
    {
        int t = 101;
        for (int i = 0; i < t; i++)
        {
            if (i == t - 1)
            {
                AsyncOperation done = SceneManager.LoadSceneAsync(nameScene);
                if (!done.isDone)
                {
                    i = 0;
                    t = 101;
                }
            }
            else { Debug.Log("load"); }
        }
    }
}

