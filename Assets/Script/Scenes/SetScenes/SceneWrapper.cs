using System.Threading.Tasks;
using UnityEngine;


internal class SceneWrapper : MonoBehaviour
{
    [Header("След.сцена")]
    [SerializeField] protected string nextScene = "null";
    [Header("Предыдущ.сцена")]
    [SerializeField] protected string backScene = "null";

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
        swithScene = new ExecutorSwithScene(nextScene, backScene);
    }
    public async Task NextSceneExecutor()
    {
       await swithScene.NextScene();
    }
    public async Task BackSceneExecutor()
    {
        await swithScene.BackScene();
    }
}

