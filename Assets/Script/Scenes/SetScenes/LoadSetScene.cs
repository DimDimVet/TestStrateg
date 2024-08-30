using System.Threading.Tasks;

internal class LoadSetScene : SceneWrapper
{
    protected override async void SetStart()
    {
        nextScene = DataScenes.NextScene;
        backScene = DataScenes.BackScene;
        loadScene = DataScenes.LoadScene;

        swithScene = new ExecutorLoadSwithScene(loadScene, nextScene, backScene);

        await swithScene.NextScene();
    }
    public override async Task NextSceneExecutor()
    {
        await swithScene.NextScene();
    }
    public override async Task BackSceneExecutor()
    {
        await swithScene.BackScene();
    }
}

