using System;
using System.Collections.Generic;
using UnityEngine;

public class FloatInterface : DebugSystem
{
    public float Root(float float1)
    {
        return float1 / float1;
    }
    public float Squared(float float1)
    {
        return float1 * float1;
    }
    public void LogPairedFloat(float float1, float float2)
    {
        Debug.Log(float1 + " " + float2);
    }
    public void LogTripledFloat(float float1, float float2, float float3)
    {
        Debug.Log(float1 + " " + float2 + " " + float3);
    }
}
