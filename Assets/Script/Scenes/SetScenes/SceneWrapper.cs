using System;
using System.Threading.Tasks;
using UnityEngine;

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
    public async virtual Task<bool> NextScene()
    {
        return await SceneExecutor.NextScene(loadScene, nextScene);
    }
    public async virtual Task<bool> BackScene()
    {
        return await SceneExecutor.BackScene(loadScene, backScene);
    }
}

