using UnityEngine;
using UnityEngine.UIElements;

public class LoadPanelMainMenu : UIWrapper
{
    [Header("Панели")]
    [SerializeField] private GameObject groundPanel;
    [SerializeField] private GameObject loadPanel;
    [Header("Кнопки")]
    [SerializeField] private CustomButtons returnButton;
    [Header("Аним")]
    [SerializeField][Range(0.1f, 5f)] private float scaleButton;
    [SerializeField][Range(0.1f, 3f)] private float duration;
    [Header("Аним Панель")]
    [SerializeField] private Transform pointTypaDefault;
    [SerializeField] private Transform pointTypaClose;
    [SerializeField][Range(0.1f, 3f)] private float durationPanel;

    private GameObject[] panels;
    private IAnimUI returnAnim;
    private IAnimUI groundPanelAnim, loadPanelAnim;
    protected override void SetOnEneble()
    {
        returnButton.OnDataButton += ExecutorReternButton;
    }
    protected override void SetStart()
    {
        returnAnim = new ScaleFocus(scaleButton, duration);

        groundPanelAnim = new MovePanel(groundPanel, pointTypaDefault, pointTypaClose, durationPanel);
        loadPanelAnim = new MovePanel(loadPanel, pointTypaDefault, pointTypaClose, durationPanel);
    }
    private void ExecutorReternButton(DataButton button)
    {
        switch (button.Pointers)
        {
            case Pointers.PointerEnter:
                returnAnim.RunDOTween(button.Transform, true);
                break;
            case Pointers.PointerExit:
                returnAnim.RunDOTween(button.Transform, false);
                break;
            case Pointers.PointerDown:
                returnAnim.RunDOTween(button.Transform, false);
                groundPanelAnim.RunDOTween(true);
                loadPanelAnim.RunDOTween(false);
                break;
            case Pointers.PointerUp:
                returnAnim.RunDOTween(button.Transform, true);
                break;
            default:
                break;
        }
    }
}

