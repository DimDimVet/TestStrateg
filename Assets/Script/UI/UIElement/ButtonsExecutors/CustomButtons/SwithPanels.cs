using System.Threading.Tasks;
using UnityEngine;

public class SwithPanels : IButtonExecutor
{
    private GameObject[] closePanels;
    private GameObject openPanel;
    public SwithPanels(GameObject[] closePanels, GameObject openPanel)
    {
        this.closePanels = closePanels;
        this.openPanel = openPanel;
        ClickActiv();
    }
    public async void ClickActiv()
    {
        for (int i = 0; i < closePanels.Length; i++)
        {
            if(closePanels[i]!= openPanel)
            { closePanels[i].SetActive(false); }
        }
        await Task.Yield();
        OpenPanel();
    }

    private async void OpenPanel()
    {
        openPanel.SetActive(true);
        await Task.Yield();
    }
}


