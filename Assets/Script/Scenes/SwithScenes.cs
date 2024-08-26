using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal static class SwithScenes
{
    public static string CurrentNameScenes;
    private static string[] nameScenes;
    private static TaskCompletionSource<object> tsk;

    public static async Task/*<object>*/ StartScene(string nameScene)
    {
        string tempName;
        //tsk = new TaskCompletionSource<object>();
        tempName=(string)await ContolMassiv(nameScene);
        CurrentNameScenes = tempName;

        //tsk.SetResult(null);
        //return await tsk.Task;
    }
    private static async Task<object> ContolMassiv(string nameScene)
    {
        tsk = new TaskCompletionSource<object>();
        if (nameScenes == null) {  nameScenes = new string[1] { nameScene }; }
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

        tsk.SetResult(nameScene);
        return await tsk.Task;
    }
}

