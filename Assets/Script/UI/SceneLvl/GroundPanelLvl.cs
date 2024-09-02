using UnityEngine;

public class GroundPanelLvl : UIWrapper
{
    [Header("Исп.скрипт")]
    [SerializeField] private SceneWrapper executorSwithScene;
    [Header("Панели")]
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject groundPanel;
    [SerializeField] private GameObject loadPanel;
    [SerializeField] private GameObject settingsPanel;
    [Header("Кнопки")]
    [SerializeField] private CustomButtons retenGameButton;
    [SerializeField] private CustomButtons loadButton;
    [SerializeField] private CustomButtons settingButton;
    [SerializeField] private CustomButtons exitMainMenuButton;
    [Header("Аним Кнопки")]
    [SerializeField][Range(0.1f, 5f)] private float scaleButton;
    [SerializeField][Range(0.1f, 3f)] private float durationButton;
    [Header("Аним Панель")]
    [SerializeField] private Transform pointTypaDefault;
    [SerializeField] private Transform pointTypaCloseGamePanel;
    [SerializeField] private Transform pointTypaCloseGroundPanel;
    [SerializeField] private Transform pointTypaClosePanels;
    [SerializeField][Range(0.1f, 3f)] private float durationPanel;

    private IAnimUI retenGameAnim, loadAnim, settingAnim, exitMainMenuAnim;
    private IAnimUI gamePanelAnim, groundPanelAnim, loadPanelAnim, settingPanelAnim;

    protected override void SetOnEneble()
    {
        retenGameButton.OnDataButton += ExecutorRetenGameButton;
        loadButton.OnDataButton += ExecutorLoadButton;
        settingButton.OnDataButton += ExecutorSettingButton;
        exitMainMenuButton.OnDataButton += ExecutorExitMainMenuButton;
    }
    protected override void SetStart()
    {
        retenGameAnim = new ScaleFocus(scaleButton, durationButton);
        loadAnim = new ScaleFocus(scaleButton, durationButton);
        settingAnim = new ScaleFocus(scaleButton, durationButton);
        exitMainMenuAnim = new ScaleFocus(scaleButton, durationButton);

        gamePanelAnim = new MovePanel(gamePanel, pointTypaDefault, pointTypaCloseGamePanel, durationPanel);
        gamePanelAnim.RunDOTween(true);
        groundPanelAnim = new MovePanel(groundPanel, pointTypaDefault, pointTypaCloseGroundPanel, durationPanel);
        groundPanelAnim.RunDOTween(false, true);
        loadPanelAnim = new MovePanel(loadPanel, pointTypaDefault, pointTypaClosePanels, durationPanel);
        loadPanelAnim.RunDOTween(false, true);
        settingPanelAnim = new MovePanel(settingsPanel, pointTypaDefault, pointTypaClosePanels, durationPanel);
        settingPanelAnim.RunDOTween(false, true);
    }
    private async void ExecutorRetenGameButton(DataButton button)
    {
        switch (button.Pointers)
        {
            case Pointers.PointerEnter:
                await retenGameAnim.RunDOTween(button.Transform, true);
                break;
            case Pointers.PointerExit:
                await retenGameAnim.RunDOTween(button.Transform, false);
                break;
            case Pointers.PointerDown:
                await groundPanelAnim.RunDOTween(false);
                await gamePanelAnim.RunDOTween(true);
                await retenGameAnim.RunDOTween(button.Transform, false);
                break;
            case Pointers.PointerUp:
                await retenGameAnim.RunDOTween(button.Transform, true);
                break;
            default:
                break;
        }
    }
    private async void ExecutorLoadButton(DataButton button)
    {
        switch (button.Pointers)
        {
            case Pointers.PointerEnter:
                await loadAnim.RunDOTween(button.Transform, true);
                break;
            case Pointers.PointerExit:
                await loadAnim.RunDOTween(button.Transform, false);
                break;
            case Pointers.PointerDown:
                await groundPanelAnim.RunDOTween(false);
                await loadPanelAnim.RunDOTween(true);
                await loadAnim.RunDOTween(button.Transform, false);
                break;
            case Pointers.PointerUp:
                await loadAnim.RunDOTween(button.Transform, true);
                break;
            default:
                break;
        }
    }
    private async void ExecutorSettingButton(DataButton button)
    {
        switch (button.Pointers)
        {
            case Pointers.PointerEnter:
                await settingAnim.RunDOTween(button.Transform, true);
                break;
            case Pointers.PointerExit:
                await settingAnim.RunDOTween(button.Transform, false);
                break;
            case Pointers.PointerDown:
                await groundPanelAnim.RunDOTween(false);
                await settingPanelAnim.RunDOTween(true);
                await settingAnim.RunDOTween(button.Transform, false);
                break;
            case Pointers.PointerUp:
                await settingAnim.RunDOTween(button.Transform, true);
                break;
            default:
                break;
        }
    }
    private async void ExecutorExitMainMenuButton(DataButton button)
    {
        switch (button.Pointers)
        {
            case Pointers.PointerEnter:
                await exitMainMenuAnim.RunDOTween(button.Transform, true);
                break;
            case Pointers.PointerExit:
                await exitMainMenuAnim.RunDOTween(button.Transform, false);
                break;
            case Pointers.PointerDown:
                if (executorSwithScene != null) { await executorSwithScene.BackScene(); }
                await exitMainMenuAnim.RunDOTween(button.Transform, false);
                break;
            case Pointers.PointerUp:
                await exitMainMenuAnim.RunDOTween(button.Transform, true);
                break;
            default:
                break;
        }
    }
    private void OnDestroy()
    {
        if (retenGameAnim != null) { retenGameAnim.StopDOTween(); }
        if (loadAnim != null) { loadAnim.StopDOTween(); }
        if (settingAnim != null) { settingAnim.StopDOTween(); }
        if (exitMainMenuAnim != null) { exitMainMenuAnim.StopDOTween(); }
    }
}
