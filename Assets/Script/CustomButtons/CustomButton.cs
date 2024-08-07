using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomButton : Button
{
    public Action<DataButton> OnDataButton { get { return onDataButton; } set { onDataButton = value; } }
    private Action<DataButton> onDataButton;
    private DataButton dataButton;
    protected override void Start()
    {
        base.Start();
        dataButton = new DataButton();
        dataButton.transform = this.transform;
    }
    //фокус
    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        dataButton.Pointers = Pointers.PointerEnter;
        onDataButton?.Invoke(dataButton);
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
        dataButton.Pointers = Pointers.PointerExit;
        onDataButton?.Invoke(dataButton);
    }
    //нажатие
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        dataButton.Pointers = Pointers.PointerDown;
        onDataButton?.Invoke(dataButton);
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        dataButton.Pointers = Pointers.PointerUp;
        onDataButton?.Invoke(dataButton);
    }
}

