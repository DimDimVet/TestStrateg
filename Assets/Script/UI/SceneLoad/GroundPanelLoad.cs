using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

internal class GroundPanelLoad : UIWrapper
{
    [Header("Индикатор загрузки")]
    [SerializeField] private Image loadImg;
    [Header("Текст загрузки")]
    [SerializeField] private Text loadTxt;

    TaskCompletionSource<object> tsk;
    protected override void SetStart()
    {
        Debug.Log("ok");
    }
    //private void ExecutorLoad()
    //{
    //    int t = 0;
    //    bool isRun = true;
    //    while (isRun)
    //    {
    //        t++;
    //        if (t >= 101)
    //        {
    //            isRun = false;
    //            t = 100;

    //            asyncOperation = SceneManager.LoadSceneAsync(_idScene);
    //            if (!asyncOperation.isDone)
    //            {
    //                isRun = true;
    //            }
    //        }
    //        loadImg.fillAmount = t * 0.01f;
    //        loadTxt.text = $"{tempTxt} {string.Format("{0:0}%", t)}";// {string.Format("{0:0}%", t)}
    //        yield return 0;
    //    }
    //}
}

