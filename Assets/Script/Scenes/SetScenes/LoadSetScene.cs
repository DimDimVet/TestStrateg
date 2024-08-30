using System.Collections;
using UnityEngine.SceneManagement;

internal class LoadSetScene : SceneWrapper
{
    private bool isRun=false;
    protected override void SetStart()
    {
        nextScene = DataScenes.TargetScena;
        StartCoroutine(LoadSceneAsync(loadScene, DataScenes.TargetScena));
    }
    protected override IEnumerator LoadSceneAsync(string sceneToLoad, string targetScene)
    {
        int i = 0;
        done = SceneManager.LoadSceneAsync(targetScene);

        while (!done.isDone)
        {
            if (!isRun) 
            { 
                while(i<=101)
                {
                    i++;
                }
                onIteration?.Invoke();
                isRun = !isRun;
            }
            
            yield return null;
        }
    }
}

