using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

public class ScaleFocus : IAnimUI
{
    private TaskCompletionSource<bool> tsk;
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
    public async Task<bool> RunDOTween( bool isActiv)
    {
        tsk = new TaskCompletionSource<bool>();
        tsk.SetResult(false);
        return await tsk.Task;
    }
    public async Task<bool> RunDOTween(Transform transform, bool isActiv)
    {
        return await Executor(transform,isActiv);
    }
    private async Task<bool> Executor(Transform transform, bool isActiv)
    {
        tsk = new TaskCompletionSource<bool>();
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
            tsk.SetResult(false);
        });

        return await tsk.Task;
    }

    public async Task<bool> StopDOTween()
    {
        tsk = new TaskCompletionSource<bool>();
        sequence.Kill();
        tsk.SetResult(false);
        return await tsk.Task;
    }
}

