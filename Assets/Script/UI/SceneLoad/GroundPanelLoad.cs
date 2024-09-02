using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

internal class GroundPanelLoad : UIWrapper
{
    [Header("Исп.скрипт")]
    [SerializeField] private SceneWrapper executorSwithScene;
    [Header("Индикатор загрузки")]
    [SerializeField] private Image loadImg;
    [Header("Текст загрузки")]
    [SerializeField] private Text loadTxt;
    [Header("Аним масштаб Image")]
    [SerializeField][Range(0.1f, 5f)] private float scaleImage;
    [SerializeField][Range(0.1f, 3f)] private float durationImage;

    TaskCompletionSource<object> tsk;
    private IAnimUI animLoadImg;

    protected override void SetOnEneble()
    {
        animLoadImg = new ScaleImage(scaleImage, durationImage);
        if (executorSwithScene != null) { executorSwithScene.OnIteration += ExecutorScaleImagen; }
    }
    protected override void SetStart()
    {
        //
    }
    private async Task<object> ExecutorScaleImagen()
    {
        tsk = new TaskCompletionSource<object>();
        await animLoadImg.RunDOTween(loadImg.gameObject.transform, true);
        tsk.SetResult(true);
        return await tsk.Task;
    }
    private void OnDestroy()
    {
        if (animLoadImg != null) { animLoadImg.StopDOTween(); }
    }
}

