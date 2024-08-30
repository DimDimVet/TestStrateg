using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;


internal class SceneWrapper : MonoBehaviour
{
    [Header("Загрузочная.сцена")]
    [SerializeField] protected string loadScene = "null";
    [Header("След.сцена")]
    [SerializeField] protected string nextScene = "null";
    [Header("Предыдущ.сцена")]
    [SerializeField] protected string backScene = "null";

    private AsyncOperation done;

    protected ISwithScene swithScene;
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
        swithScene = new ExecutorSwithScene(loadScene,nextScene, backScene);
    }
    public virtual async Task NextSceneExecutor()
    {
        SwithScene(nextScene);
       //await swithScene.NextScene();
    }
    public virtual async Task BackSceneExecutor()
    {
        await swithScene.BackScene();
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

