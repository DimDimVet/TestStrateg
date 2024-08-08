using UnityEngine;

public class SettingPanelMainMenu : UIWrapper
{
    [Header("Панели")]
    [SerializeField] private GameObject groundPanel;
    [SerializeField] private GameObject settingPanel;
    [Header("Кнопки")]
    [SerializeField] private CustomButtons returnButton;

    private GameObject[] panels;
    private IButtonExecutor executor;
    protected override void SetOnEneble()
    {
        returnButton.OnDataButton += ExecutorReternButton;
    }
    protected override void SetStart()
    {
        panels = new GameObject[] { groundPanel, settingPanel };
    }
    private void ExecutorReternButton(DataButton button)
    {
        switch (button.Pointers)
        {
            case Pointers.PointerEnter:

                break;
            case Pointers.PointerExit:

                break;
            case Pointers.PointerDown:
                executor = new SwithPanels(panels, groundPanel);
                break;
            case Pointers.PointerUp:

                break;
            default:
                break;
        }
    }
}

