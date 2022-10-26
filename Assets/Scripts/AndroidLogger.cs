using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AndroidLogger : Logger
{
    const string pluginName = "com.example.loggermanager.CavenaghiLogger";
    string path;

    AndroidJavaClass androidLoggerClass;
    AndroidJavaObject androidLoggerObject;

    public AndroidLogger(string path, TMPro.TextMeshProUGUI text)
    {
        this.text = text;
        this.path = path;

        androidLoggerClass = new AndroidJavaClass(pluginName);
        androidLoggerObject = androidLoggerClass.CallStatic<AndroidJavaObject>("GetInstance", path);

        AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");

        androidLoggerObject.CallStatic("SetUnityActivity", jo);
    }

    private void ShowAlert(string title, string message, Action confirm = null, Action cancel = null)
    {
        Alert alert = new Alert();
        alert.positiveAction = confirm;
        alert.negativeAction = cancel;
        androidLoggerObject.Call("CreateAlert", new object[] { title, message, alert });
        androidLoggerObject.Call("ShowAlert");
    }

    public override void Clear()
    {
        ShowAlert("All records will be deleted.", "Do you want to continue?", () => { androidLoggerObject.Call("ClearLogs"); text.text = ""; });
        
    }

    public override void AddLog(string log)
    {
        androidLoggerObject.Call("AddLog", log + "\n");
    }

    public override void ShowAllLogs()
    {
        text.text = androidLoggerObject.Call<string>("GetLogs");
    }

    public override void WriteLog()
    {
        androidLoggerObject.Call("WriteLog");
    }
}
