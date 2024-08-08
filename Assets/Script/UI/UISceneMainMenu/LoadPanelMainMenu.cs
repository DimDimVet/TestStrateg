using UnityEngine;

public class LoadPanelMainMenu : UIWrapper
{
    [Header("Панели")]
    [SerializeField] private GameObject groundPanel;
    [SerializeField] private GameObject loadPanel;
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
        panels = new GameObject[] { groundPanel, loadPanel };
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

