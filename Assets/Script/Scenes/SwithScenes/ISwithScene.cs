using System.Threading.Tasks;

internal interface ISwithScene
{
    Task<object> NextScene();
    Task<object> BackScene();
}

