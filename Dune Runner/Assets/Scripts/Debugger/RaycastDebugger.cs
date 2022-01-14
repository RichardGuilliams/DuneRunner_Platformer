using System;
using System.Collections.Generic;
using UnityEngine;
public class RaycastDebugger: DebugManager
{
    private RaycastHit2D ray;
    public bool rayName;
    public enum LogType
    {
        Log,
        Positions,
    }

    public LogType type;

    public void Log()
    {
        switch (type)
        {
            case LogType.Log:

                break;
        }
    }

    public void LogRay(RaycastHit2D hit)
    {
        if (isEnabled)
        {
            LogContinuous(hit);
            Debug.Log(hit);
            isEnabled = false;
        }
    }

    public void LogContinuous(RaycastHit2D hit)
    {
        if (continuousLog)
        {
            Debug.Log(hit);
            return;
        }
    }

}



