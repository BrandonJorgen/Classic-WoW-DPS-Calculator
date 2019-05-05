using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BoolEvent : MonoBehaviour
{
    public UnityEvent BoolTrue, BoolFalse;
    private bool trueEventCheck, falseEventCheck;
    
    void Update()
    {
        //Invokes bool enabled event once
        if (trueEventCheck == false)
        {
            if (GetComponent<Toggle>().isOn)
            {
                falseEventCheck = false;
                BoolTrue.Invoke();
                trueEventCheck = true;
            }
        }

        //Invokes bool disabled event once
        if (GetComponent<Toggle>().isOn == false)
        {
            if (falseEventCheck == false)
            {
                trueEventCheck = false;
                BoolFalse.Invoke();
                falseEventCheck = true;
            }
        }
    }
}
