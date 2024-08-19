using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

public class ScaleFocus : IAnimUI
{
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
    public async Task RunDOTween( bool isActiv)
    {
        await Task.Yield();
    }
    public async Task RunDOTween(Transform transform, bool isActiv)
    {

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
        sequence.AppendCallback(() =>
                {

                });
        //await Task.Delay(1000);
        await Task.Yield();
    }
}

