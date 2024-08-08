using System.Threading.Tasks;
using UnityEngine;

public class Test1 : MonoBehaviour
{
    [SerializeField] CustomButtons customButton1;
    [SerializeField] CustomButtons customButton2;
    //Pointers gg;
    //Transform transformTemp;
    //IAnimButtons AnimButtons;
    //bool isStopDOT = true;
    //Task isTaskStop;
    private void OnEnable()
    {
        customButton1.OnDataButton += CustDataButton1;
        customButton2.OnDataButton += CustDataButton2;
    }
    private void Start()
    {
        //AnimButtons = new DOTween1();
    }
    private void CustDataButton1(DataButton button)
    {
        //if (isTaskStop != null)
        //{
        //    Debug.Log(isTaskStop.IsCompleted);
        //    if (button.Pointers == Pointers.PointerDown && isTaskStop.IsCompleted)
        //    {
        //        isStopDOT = false;
        //        gg = button.Pointers;
        //        isTaskStop = AnimButtons.DOTwin(customButton1.transform);
        //    }
        //}
        //else { isTaskStop = AnimButtons.DOTwin(customButton1.transform); }
    }
    private void CustDataButton2(DataButton button)
    {
        //if (isTaskStop != null)
        //{
        //    Debug.Log(isTaskStop.IsCompleted);
        //    if (button.Pointers == Pointers.PointerDown && isTaskStop.IsCompleted)
        //    {
        //        isStopDOT = false;
        //        gg = button.Pointers;
        //        isTaskStop = AnimButtons.DOTwin(customButton2.transform);
        //    }
        //}
        //else { isTaskStop = AnimButtons.DOTwin(customButton2.transform); }
    }
}

