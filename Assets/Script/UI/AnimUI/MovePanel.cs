using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

public class MovePanel : IAnimUI
{
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

    public async Task RunDOTween(bool isActiv)
    {
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

        sequence.AppendCallback(() =>
        {
            sequence.Kill();
        });

        await Task.Yield();
    }
    public async Task RunDOTween(Transform transform, bool isActiv)
    {
        await Task.Yield();
    }
}

