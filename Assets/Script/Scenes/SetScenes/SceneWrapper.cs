using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

internal class SceneWrapper : MonoBehaviour
{
    public Func<Task<object>> OnIteration { get { return onIteration; } set { onIteration = value; } }
    protected Func<Task<object>> onIteration;

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

        for (int i = 0; i < 101; i++)
        {

        }

        Debug.Log("zap");
        while (!done.isDone)
        {
            Debug.Log("-");
            // Обновление индикатора загрузки, если необходимо
            yield return null;
        }
    }
}

