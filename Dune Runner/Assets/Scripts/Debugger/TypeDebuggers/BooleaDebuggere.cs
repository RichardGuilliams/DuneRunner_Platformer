using System;
using System.Collections.Generic;
using UnityEngine;

public class BooleaDebuggere: DebugSystem
{
    public void LogBoolean(string boolName, bool boolean)
    {
        Debug.Log(boolName + ": " + boolean);
    }
}
