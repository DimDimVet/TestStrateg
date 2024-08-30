using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

internal class SceneWrapper : MonoBehaviour
{
    public Action OnIteration { get { return onIteration; } set { onIteration = value; } }
    protected Action onIteration;

    [Header("Загрузочная.сцена")]
    [SerializeField] protected string loadScene = "null";
    [Header("След.сцена")]
    [SerializeField] protected string nextScene = "null";
    [Header("Предыдущ.сцена")]
    [SerializeField] protected string backScene = "null";

    protected AsyncOperation done;
    private void OnEnable()
    {
        SetOnEneble();
    }
    protected virtual void SetOnEneble()
    {
        //
    }
    private void Start()
    {
        SetStart();
    }
    protected virtual void SetStart()
    {
        //
    }
    public virtual void NextScene()
    {
        StartCoroutine(LoadSceneAsync(loadScene, nextScene));
    }
    public virtual void BackScene()
    {
        StartCoroutine(LoadSceneAsync(loadScene, backScene));
    }
    protected virtual IEnumerator LoadSceneAsync(string sceneToLoad, string targetScene)
    {
        DataScenes.TargetScena = targetScene;
        done = SceneManager.LoadSceneAsync(sceneToLoad);

        while (!done.isDone)
        {
            // Обновление индикатора загрузки, если необходимо
            yield return null;
        }
    }
}

