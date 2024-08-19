using System.Threading.Tasks;
using Unity.VisualScripting;
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
    [Header("Аним Кнопки")]
    [SerializeField][Range(0.1f, 5f)] private float scaleButton;
    [SerializeField][Range(0.1f, 3f)] private float durationButton;
    [Header("Аним Панель")]
    [SerializeField] private Transform pointTypaDefault;
    [SerializeField] private Transform pointTypaClose;
    [SerializeField][Range(0.1f, 3f)] private float durationPanel;

    private GameObject[] panels;
    private IAnimUI gameAnim, loadAnim, settingAnim, exitAnim;
    private IAnimUI groundPanelAnim, loadPanelAnim, settingPanelAnim;
    protected override void SetOnEneble()
    {
        gameButton.OnDataButton += ExecutorGameButton;
        loadButton.OnDataButton += ExecutorLoadButton;
        settingButton.OnDataButton += ExecutorSettingButton;
        exitButton.OnDataButton += ExecutorExitButton;
    }
    protected override void SetStart()
    {
        gameAnim = new ScaleFocus(scaleButton, durationButton);
        loadAnim = new ScaleFocus(scaleButton, durationButton);
        settingAnim = new ScaleFocus(scaleButton, durationButton);
        exitAnim = new ScaleFocus(scaleButton, durationButton);

        groundPanelAnim=new MovePanel(groundPanel,pointTypaDefault, pointTypaClose, durationPanel);
        groundPanelAnim.RunDOTween(true);
        loadPanelAnim = new MovePanel(loadPanel,pointTypaDefault, pointTypaClose, durationPanel);
        loadPanelAnim.RunDOTween(false);
        settingPanelAnim = new MovePanel(settingPanel,pointTypaDefault, pointTypaClose, durationPanel);
        settingPanelAnim.RunDOTween(false);
        //panels = new GameObject[] { groundPanel, loadPanel, settingPanel };
        //movePanels = new MovePanel(panels, pointTypaDefault, pointTypaClose, durationPanel);
        //movePanels.RunDOTween(groundPanel.transform, true);
    }
    private void ExecutorGameButton(DataButton button)
    {
        switch (button.Pointers)
        {
            case Pointers.PointerEnter:
                gameAnim.RunDOTween(button.Transform, true);
                break;
            case Pointers.PointerExit:
                gameAnim.RunDOTween(button.Transform, false);
                break;
            case Pointers.PointerDown:
                gameAnim.RunDOTween(button.Transform, false);
                //executor = new SwithPanels(panels, null);
                break;
            case Pointers.PointerUp:
                gameAnim.RunDOTween(button.Transform, true);
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
                loadAnim.RunDOTween(button.Transform, true);
                break;
            case Pointers.PointerExit:
                loadAnim.RunDOTween(button.Transform, false);
                break;
            case Pointers.PointerDown:
                loadAnim.RunDOTween(button.Transform, false);
                groundPanelAnim.RunDOTween(false);
                loadPanelAnim.RunDOTween(true);
                break;
            case Pointers.PointerUp:
                loadAnim.RunDOTween(button.Transform, true);
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
                settingAnim.RunDOTween(button.Transform, true);
                break;
            case Pointers.PointerExit:
                settingAnim.RunDOTween(button.Transform, false);
                break;
            case Pointers.PointerDown:
                settingAnim.RunDOTween(button.Transform, false);
                groundPanelAnim.RunDOTween(false);
                settingPanelAnim.RunDOTween(true);
                break;
            case Pointers.PointerUp:
                settingAnim.RunDOTween(button.Transform, true);
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
                exitAnim.RunDOTween(button.Transform, true);
                break;
            case Pointers.PointerExit:
                exitAnim.RunDOTween(button.Transform, false);
                break;
            case Pointers.PointerDown:
                exitAnim.RunDOTween(button.Transform, false);
                break;
            case Pointers.PointerUp:
                exitAnim.RunDOTween(button.Transform, true);
                break;
            default:
                break;
        }
    }
}

