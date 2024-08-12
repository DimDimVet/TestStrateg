using UnityEngine;

public class GroundPanelMainMenu : UIWrapper
{
    [Header("Панели")]
    [SerializeField] private GameObject groundPanel;
    [SerializeField] private GameObject loadPanel;
    [SerializeField] private GameObject settingPanel;
    [Header("Кнопки")]
    [SerializeField] private CustomButtons gameButton;
    [SerializeField] private CustomButtons loadButton;
    [SerializeField] private CustomButtons settingButton;
    [SerializeField] private CustomButtons exitButton;
    [Header("Аним")]
    [SerializeField][Range(0.1f,5f)] private float scaleButton;
    [SerializeField][Range(0.1f, 3f)] private float duration;

    private GameObject[] panels;
    private IButtonExecutor executor;
    private IAnimUI gameAnim, loadAnim, settingAnim, exitAnim;
    protected override void SetOnEneble()
    {
        gameButton.OnDataButton += ExecutorGameButton;
        loadButton.OnDataButton += ExecutorLoadButton;
        settingButton.OnDataButton += ExecutorSettingButton;
        exitButton.OnDataButton += ExecutorExitButton;
    }
    protected override void SetStart()
    {
        panels = new GameObject[] { groundPanel, loadPanel, settingPanel };
        executor = new SwithPanels(panels, groundPanel);
        gameAnim = new ScaleFocus(scaleButton, duration);
        loadAnim = new ScaleFocus(scaleButton, duration);
        settingAnim = new ScaleFocus(scaleButton, duration);
        exitAnim = new ScaleFocus(scaleButton, duration);
    }
    private void ExecutorGameButton(DataButton button)
    {
        switch (button.Pointers)
        {
            case Pointers.PointerEnter:
                gameAnim.DOTwin(button.Transform,true);
                break;
            case Pointers.PointerExit:
                gameAnim.DOTwin(button.Transform, false);
                break;
            case Pointers.PointerDown:
                gameAnim.DOTwin(button.Transform, false);
                //executor = new SwithPanels(panels, null);
                break;
            case Pointers.PointerUp:
                gameAnim.DOTwin(button.Transform, true);
                break;
            default:
                break;
        }
    }
    private void ExecutorLoadButton(DataButton button)
    {
        switch (button.Pointers)
        {
            case Pointers.PointerEnter:
                loadAnim.DOTwin(button.Transform, true);
                break;
            case Pointers.PointerExit:
                loadAnim.DOTwin(button.Transform, false);
                break;
            case Pointers.PointerDown:
                loadAnim.DOTwin(button.Transform, false);
                executor = new SwithPanels(panels, loadPanel);
                break;
            case Pointers.PointerUp:
                loadAnim.DOTwin(button.Transform, true);
                break;
            default:
                break;
        }
    }
    private void ExecutorSettingButton(DataButton button)
    {
        switch (button.Pointers)
        {
            case Pointers.PointerEnter:
                settingAnim.DOTwin(button.Transform, true);
                break;
            case Pointers.PointerExit:
                settingAnim.DOTwin(button.Transform, false);
                break;
            case Pointers.PointerDown:
                settingAnim.DOTwin(button.Transform, false);
                executor = new SwithPanels(panels, settingPanel);
                break;
            case Pointers.PointerUp:
                settingAnim.DOTwin(button.Transform, true);
                break;
            default:
                break;
        }
    }
    private void ExecutorExitButton(DataButton button)
    {
        switch (button.Pointers)
        {
            case Pointers.PointerEnter:
                exitAnim.DOTwin(button.Transform, true);
                break;
            case Pointers.PointerExit:
                exitAnim.DOTwin(button.Transform, false);
                break;
            case Pointers.PointerDown:
                exitAnim.DOTwin(button.Transform, false);
                break;
            case Pointers.PointerUp:
                exitAnim.DOTwin(button.Transform, true);
                break;
            default:
                break;
        }
    }
}

