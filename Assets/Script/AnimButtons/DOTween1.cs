
using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

public class DOTween1 : IAnimButtons
{
    //private async Task RotateTestAsync(Transform transformObject, float duration)
    //{
    //    float timer = 0;
    //    while (timer < 10f)
    //    {
    //        timer = Mathf.Min(timer + Time.deltaTime / duration);
    //        transformObject.Rotate(Vector3.up, rotatingSpeed * Time.deltaTime);
    //        await Task.Yield();
    //    }
    //}
    private Vector3 defaultPosition;
    bool isComplite = false;
    public async Task DOTwin(Transform transform)
    {
        defaultPosition = transform.position;
        transform.DOMoveX(defaultPosition.x - 1, 5);
        transform.DORestart();
        DOTween.Play(transform);

        await Task.Yield();
        await Task.Delay(1000);

        Debug.Log("+");
    }
}

