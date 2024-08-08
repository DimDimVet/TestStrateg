using DG.Tweening;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class ScaleFocus : IAnimUI
{
    private Sequence sequence;
    private float duration;
    private float activScale;
    private Vector3 currentScale;
    private Vector3 newScale;

    private CancellationTokenSource cancelTokenSource;
    private CancellationToken token;
    public ScaleFocus( float activScale, float duration)
    {
        this.activScale = activScale;
        this.duration=duration; 
        sequence = DOTween.Sequence();
        cancelTokenSource = new CancellationTokenSource();
        token = cancelTokenSource.Token;
    }
    private async Task SetTransform(Transform transform)
    {
        this.currentScale = transform.localScale;
        this.newScale = currentScale * activScale;
        await Task.Yield();
    }
    public async Task DOTwin(Transform transform, bool isActiv)
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
                    //Task.Delay(1);
                });

        await Task.Yield();
        Debug.Log("jr");
    }
}

