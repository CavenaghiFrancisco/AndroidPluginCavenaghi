package com.example.loggermanager;

import android.util.Log;

public class CavenaghiLogger
{
    private static CavenaghiLogger instance = new CavenaghiLogger();
    private static final String TAG = "CaveLogger -> ";

    public static CavenaghiLogger GetInstance()
    {
        return instance;
    }

    public void GetLog(String str)
    {
        Log.d(TAG, str);
    }
}
