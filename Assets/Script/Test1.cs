
using System;
using UnityEngine;

public class Test1 : MonoBehaviour
{
    [SerializeField] CustomButton customButton;
    Pointers gg;
    Transform transformTemp;
    int i;
    private void OnEnable()
    {
        customButton.OnDataButton += CustDataButton;
    }

    private void CustDataButton(DataButton button)
    {
        gg=button.Pointers;
        Debug.Log(gg);
        transformTemp= button.transform;
        i++;
        button.transform.position= new Vector3(transformTemp.position.x + i, transformTemp.position.y + i,transformTemp.position.z);
    }

}

