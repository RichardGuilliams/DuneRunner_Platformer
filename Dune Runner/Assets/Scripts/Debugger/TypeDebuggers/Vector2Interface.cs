using System;
using System.Collections.Generic;
using UnityEngine;
public class Vector2Interface : DebugSystem
{
    public void LogVector2(Vector2 vector, FloatInterface Float)
    {
        Float.LogPairedFloat(vector.x, vector.y);
        Float.LogPairedFloat(vector.normalized.x, vector.normalized.y);
        Debug.Log(vector.magnitude);
    }
}
