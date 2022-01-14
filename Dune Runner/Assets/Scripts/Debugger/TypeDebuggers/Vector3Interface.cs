using System;
using System.Collections.Generic;
using UnityEngine;

public class Vector3Interface : DebugSystem
{
    public void LogVector3(Vector3 vector, FloatInterface Float)
    {
        Float.LogTripledFloat(vector.x, vector.y, vector.z);
        Float.LogTripledFloat(vector.normalized.x, vector.normalized.y, vector.normalized.z);
        Debug.Log(vector.magnitude);
    }

    public void LogDistance(Vector3 vector, Vector3 vector2, FloatInterface Float)
    {
        float a = Float.Squared(vector.x + vector2.x);
        float b = Float.Squared(vector.y + vector2.y);
        float c = Float.Root(a + b);
    }
}

