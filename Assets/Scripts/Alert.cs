using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alert : AndroidJavaProxy
{
    public Action positiveAction;
    public Action negativeAction;
    const string alertInterfaceName = "com.example.loggermanager.Alert";

    public Alert() : base(alertInterfaceName){}

    public void OnPositive()
    {
        positiveAction?.Invoke();
    }

    public void OnNegative()
    {
        negativeAction?.Invoke();
    }
}
