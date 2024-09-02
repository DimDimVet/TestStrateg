using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

public class MovePanel : IAnimUI
{
    TaskCompletionSource<bool> tsk;
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

    public async Task<bool> RunDOTween(bool isActiv)
    {
        return await Executor(isActiv);
    }
    public async Task<bool> RunDOTween(Transform transform, bool isActiv)
    {
        tsk = new TaskCompletionSource<bool>();
        tsk.SetResult(false);
        return await tsk.Task;
    }
    private async Task<bool> Executor(bool isActiv)
    {
        tsk = new TaskCompletionSource<bool>();
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
            tsk.SetResult(false);
            sequence.Kill();
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

