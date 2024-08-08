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
    private IAnimUI anim;
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
        anim = new ScaleFocus(scaleButton, duration);
    }
    private void ExecutorGameButton(DataButton button)
    {
        switch (button.Pointers)
        {
            case Pointers.PointerEnter:
                anim.DOTwin(button.Transform,true);
                break;
            case Pointers.PointerExit:
                Debug.Log("GameExit");
                anim.DOTwin(button.Transform, false);
                break;
            case Pointers.PointerDown:
                //executor = new SwithPanels(panels, null);
                break;
            case Pointers.PointerUp:

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
                anim.DOTwin(button.Transform, true);
                break;
            case Pointers.PointerExit:
                anim.DOTwin(button.Transform, false);
                break;
            case Pointers.PointerDown:
                executor = new SwithPanels(panels, loadPanel);
                break;
            case Pointers.PointerUp:

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
                anim.DOTwin(button.Transform, true);
                break;
            case Pointers.PointerExit:
                anim.DOTwin(button.Transform, false);
                break;
            case Pointers.PointerDown:
                executor = new SwithPanels(panels, settingPanel);
                break;
            case Pointers.PointerUp:

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
                anim.DOTwin(button.Transform, true);
                break;
            case Pointers.PointerExit:
                anim.DOTwin(button.Transform, false);
                break;
            case Pointers.PointerDown:

                break;
            case Pointers.PointerUp:

                break;
            default:
                break;
        }
    }
}

