using UnityEngine;

public class LoadPanelLvl : UIWrapper
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
    private async void ExecutorReternButton(DataButton button)
    {
        switch (button.Pointers)
        {
            case Pointers.PointerEnter:
                await returnAnim.RunDOTween(button.Transform, true);
                break;
            case Pointers.PointerExit:
                await returnAnim.RunDOTween(button.Transform, false);
                break;
            case Pointers.PointerDown:
                await loadPanelAnim.RunDOTween(false);
                await groundPanelAnim.RunDOTween(true);
                await returnAnim.RunDOTween(button.Transform, false);
                break;
            case Pointers.PointerUp:
                await returnAnim.RunDOTween(button.Transform, true);
                break;
            default:
                break;
        }
    }
    private void OnDestroy()
    {
        if (returnAnim != null) { returnAnim.StopDOTween(); }
        if (groundPanelAnim != null) { groundPanelAnim.StopDOTween(); }
        if (loadPanelAnim != null) { loadPanelAnim.StopDOTween(); }
    }
}

