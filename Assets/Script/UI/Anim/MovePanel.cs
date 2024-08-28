using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

public class MovePanel : IAnimUI
{
    TaskCompletionSource<object> tsk;
    private Sequence sequence;
    private float duration;

    private GameObject panel;
    private Vector3 pointTypaClose;
    private Vector3 pointTypaDefault;

    public MovePanel(GameObject panel, Transform pointTypadDefault, Transform pointTypaClose, float duration)
    {
        this.panel = panel;
        this.pointTypaDefault = pointTypadDefault.position;
        this.pointTypaClose = pointTypaClose.position;
        this.duration = duration;
    }

    public async Task<object> RunDOTween(bool isActiv)
    {
        return await Executor(isActiv);
    }
    public async Task<object> RunDOTween(Transform transform, bool isActiv)
    {
        tsk = new TaskCompletionSource<object>();
        tsk.SetResult(null);
        return await tsk.Task;
    }
    private Task<object> Executor(bool isActiv)
    {
        tsk = new TaskCompletionSource<object>();
        sequence.Kill();
        sequence = DOTween.Sequence();
        if (isActiv)
        {
            sequence.Append(panel.transform.DOMove(pointTypaDefault, duration));
        }
        else
        {
            sequence.Append(panel.transform.DOMove(pointTypaClose, duration));
        }

        sequence.OnComplete(() =>
        {
            tsk.SetResult(null);
            sequence.Kill();
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

