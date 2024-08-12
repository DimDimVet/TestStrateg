using UnityEngine;

public class SettingPanelMainMenu : UIWrapper
{
    [Header("Панели")]
    [SerializeField] private GameObject groundPanel;
    [SerializeField] private GameObject settingPanel;
    [Header("Кнопки")]
    [SerializeField] private CustomButtons returnButton;
    [Header("Аним")]
    [SerializeField][Range(0.1f, 5f)] private float scaleButton;
    [SerializeField][Range(0.1f, 3f)] private float duration;

    private GameObject[] panels;
    private IButtonExecutor executor;
    private IAnimUI returnAnim;
    protected override void SetOnEneble()
    {
        returnButton.OnDataButton += ExecutorReternButton;
    }
    protected override void SetStart()
    {
        panels = new GameObject[] { groundPanel, settingPanel };
        returnAnim = new ScaleFocus(scaleButton, duration);
    }
    private void ExecutorReternButton(DataButton button)
    {
        switch (button.Pointers)
        {
            case Pointers.PointerEnter:
                returnAnim.DOTwin(button.Transform, true);
                break;
            case Pointers.PointerExit:
                returnAnim.DOTwin(button.Transform, false);
                break;
            case Pointers.PointerDown:
                executor = new SwithPanels(panels, groundPanel);
                returnAnim.DOTwin(button.Transform, false);
                break;
            case Pointers.PointerUp:
                returnAnim.DOTwin(button.Transform, true);
                break;
            default:
                break;
        }
    }
}

