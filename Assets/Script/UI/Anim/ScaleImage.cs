﻿using DG.Tweening;
using System;
using System.Threading.Tasks;
using UnityEngine;


internal class ScaleImage : IAnimUI
{
    private TaskCompletionSource<bool> tsk;
    private Sequence sequence;
    private float duration;
    private float activScale;
    private Vector3 currentScale;
    private Vector3 newScale;

    public ScaleImage(float activScale, float duration)
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
    public async Task<bool> RunDOTween(bool isActiv, bool isDefaulPosition = false)
    {
        tsk = new TaskCompletionSource<bool>();
        tsk.SetResult(false);
        return await tsk.Task;
    }

    public async Task<bool> RunDOTween(Transform transform, bool isActiv, bool isDefaulPosition = false)
    {
        return await Executor(transform, isActiv, isDefaulPosition);
    }
    private async Task<bool> Executor(Transform transform, bool isActiv, bool isDefaulPosition = false)
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
            sequence.Append(transform.DOScale(currentScale, duration));
        }
        //else
        //{
        //    sequence.Append(transform.DOScale(currentScale, duration));
        //}
        sequence.OnComplete(() =>
        {
            tsk.SetResult(false);
        });
        //sequence.SetLoops(-1, LoopType.Restart);
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

