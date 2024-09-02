using System;
using UnityEngine;

internal class GamePanelLvl : UIWrapper
{
    [Header("Панели")]
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject groundPanel;
    [Header("Кнопки")]
    [SerializeField] private CustomButtons menuButton;
    [Header("Аним Кнопки")]
    [SerializeField][Range(0.1f, 5f)] private float scaleButton;
    [SerializeField][Range(0.1f, 3f)] private float durationButton;
    [Header("Аним Панель")]
    [SerializeField] private Transform pointTypaDefault;
    [SerializeField] private Transform pointTypaCloseGamePanel;
    [SerializeField] private Transform pointTypaCloseGroundPanel;
    [SerializeField][Range(0.1f, 3f)] private float durationPanel;

    private IAnimUI menuAnim;
    private IAnimUI groundPanelAnim, gamePanelAnim;

    protected override void SetOnEneble()
    {
        menuButton.OnDataButton += ExecutorMenuButton;
    }
    protected override void SetStart()
    {
        menuAnim = new ScaleFocus(scaleButton, durationButton);

        gamePanelAnim = new MovePanel(gamePanel, pointTypaDefault, pointTypaCloseGamePanel, durationPanel);
        gamePanelAnim.RunDOTween(true);
        groundPanelAnim = new MovePanel(groundPanel, pointTypaDefault, pointTypaCloseGroundPanel, durationPanel);
        groundPanelAnim.RunDOTween(false, true);
    }
    private async void ExecutorMenuButton(DataButton button)
    {
        switch (button.Pointers)
        {
            case Pointers.PointerEnter:
                await menuAnim.RunDOTween(button.Transform, true);
                break;
            case Pointers.PointerExit:
                await menuAnim.RunDOTween(button.Transform, false);
                break;
            case Pointers.PointerDown:
                await gamePanelAnim.RunDOTween(false);
                await groundPanelAnim.RunDOTween(true);
                await menuAnim.RunDOTween(button.Transform, false);
                break;
            case Pointers.PointerUp:
                await menuAnim.RunDOTween(button.Transform, true);
                break;
            default:
                break;
        }
    }
    private void OnDestroy()
    {
        if (menuAnim != null) { menuAnim.StopDOTween(); }
    }
}

