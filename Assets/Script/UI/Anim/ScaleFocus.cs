using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

public class ScaleFocus : IAnimUI
{
    private TaskCompletionSource<object> tsk;
    private Sequence sequence;
    private float duration;
    private float activScale;
    private Vector3 currentScale;
    private Vector3 newScale;

    public ScaleFocus(float activScale, float duration)
    {
        this.activScale = activScale;
        this.duration = duration;
        sequence = DOTween.Sequence();
    }
    private async Task SetTransform(Transform transform)
    {
        this.currentScale = transform.localScale;
        this.newScale = currentScale * activScale;
        await Task.Yield();
    }
    public async Task<object> RunDOTween( bool isActiv)
    {
        tsk = new TaskCompletionSource<object>();
        tsk.SetResult(null);
        return await tsk.Task;
    }
    public async Task<object> RunDOTween(Transform transform, bool isActiv)
    {
        return await Executor(transform,isActiv);
    }
    private async Task<object> Executor(Transform transform, bool isActiv)
    {
        tsk = new TaskCompletionSource<object>();
        if (currentScale == Vector3.zero)
        {
            await SetTransform(transform);
        }

        sequence.Kill();
        sequence = DOTween.Sequence();

        if (isActiv)
        {
            sequence.Append(transform.DOScale(newScale, duration));
        }
        else
        {
            sequence.Append(transform.DOScale(currentScale, duration));
        }
        sequence.OnComplete(() =>
        {
            tsk.SetResult(null);
        });

        return tsk.Task;
    }

    public async Task<object> StopDOTween()
    {
        tsk = new TaskCompletionSource<object>();
        sequence.Kill();
        tsk.SetResult(null);
        return await tsk.Task;
    }
}

