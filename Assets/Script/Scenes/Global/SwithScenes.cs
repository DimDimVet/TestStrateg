using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

internal static class SwithScenes
{
    public static string NextScene;
    public static string BackScene;

    public static string CurrentNameScenes;
    private static string[] nameScenes;
    private static TaskCompletionSource<object> tskContolMassiv, tsk;
    private static AsyncOperation done;
    private static bool isRun = true;
    public static Action<bool> OnTikLoad { get { return onTikLoad; } /*set { onEndPressButton = value; }*/ }
    private static Action<bool> onTikLoad;

    public static async Task<object> StartScene(string nameScene)
    {
        string tempName;
        tsk = new TaskCompletionSource<object>();
        tempName = (string)await ContolMassiv(nameScene);
        CurrentNameScenes = tempName;

        while (isRun)
        {
            done = SceneManager.LoadSceneAsync(CurrentNameScenes);
            if (!done.isDone)
            {
                isRun = true;
            }
            else
            {
                isRun = false;
            }
        }
        tsk.SetResult(!isRun);
        return await tsk.Task;
    }
    private static async Task<object> ContolMassiv(string nameScene)
    {
        tskContolMassiv = new TaskCompletionSource<object>();
        if (nameScenes == null) { nameScenes = new string[1] { nameScene }; }
        else
        {
            for (int i = 0; i < nameScenes.Length; i++)
            {
                if (nameScenes[i] == nameScene)
                {
                    tsk.SetResult(nameScene);
                    return await tsk.Task;
                }
            }

            int newLength = nameScenes.Length + 1;
            Array.Resize(ref nameScenes, newLength);
            nameScenes[newLength - 1] = nameScene;
        }

        tskContolMassiv.SetResult(nameScene);
        return await tskContolMassiv.Task;
    }
}

