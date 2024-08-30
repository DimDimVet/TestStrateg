﻿using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

internal class ExecutorSwithScene : ISwithScene
{
    //private string nextScene;
    //private string backScene;
    private string loadScene;
    private TaskCompletionSource<object> tsk;
    private static AsyncOperation done;
    internal ExecutorSwithScene(string loadScene, string nextScene, string backScene)
    {
        //this.nextScene = nextScene;
        //this.backScene = backScene;
        this.loadScene = loadScene;
        DataScenes.NextScene= nextScene;
        DataScenes.BackScene= backScene;
        DataScenes.LoadScene= loadScene;
    }
    public async Task<object> BackScene()
    {
        tsk = new TaskCompletionSource<object>();
        SwithScene(loadScene);
        tsk.SetResult(null);
        return await tsk.Task;
    }

    public async Task<object> NextScene()
    {
        tsk = new TaskCompletionSource<object>();
        SwithScene(loadScene);
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
                done = SceneManager.LoadSceneAsync(nameScene);
                if (!done.isDone)
                {
                    t = 101;
                }
            }
            else { Debug.Log("load"); }
        }
    }
}

