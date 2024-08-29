using System.Collections;
using System.Threading;
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
        AsyncOperation done = SceneManager.LoadSceneAsync(nameScene);

        while (!done.isDone)
        {
            Thread.Sleep(100);
            Debug.Log("load");
            // Обновление индикатора загрузки, если необходимо
            
        }
        //tsk = new TaskCompletionSource<object>();
        //done = new AsyncOperation();
        //int t = 0;
        //Debug.Log("start");
        ////for (int i = 0; i < 1000; i++)

        //while (isRun)
        //{

        //    t++;
        //    Thread.Sleep(10);
        //    if (t >= 101)
        //    {
        //        Debug.Log(t);
        //        isRun = false;
        //        t = 0;


        //        done = SceneManager.LoadSceneAsync(nameScene);

        //        Debug.Log(done.isDone);
        //        if (!done.isDone)
        //        {
        //            Debug.Log("no");
        //            isRun = true;
        //        }
        //        else
        //        {
        //            Debug.Log("ok");
        //            //break;
        //        }

        //    }

        //}
        //Thread.Sleep(1);
        //done = SceneManager.LoadSceneAsync(nameScene);
        //Thread.Sleep(1);
        //Debug.Log("ok");
        //done = SceneManager.LoadSceneAsync(nameScene);

        //Debug.Log(done.isDone);
        //tsk.SetResult(!isRun);
        //return await tsk.Task;
    }
}

