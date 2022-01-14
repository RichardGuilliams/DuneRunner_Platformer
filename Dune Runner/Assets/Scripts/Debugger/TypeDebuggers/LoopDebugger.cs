using System;
using System.Collections.Generic;
using UnityEngine;

public class LoopDebugger
{
    #region Parameters
    public ComparisonOperator compare = new ComparisonOperator();
    public bool isEnabled;
    public bool continuous;
    public object paramA;
    public object paramB;
    public int iteration;
    public int MaxIteration;
    public int logCounter;
    public int loopId;
    public Vector4 vector;

    #endregion

    public void CountDown()
    {
        if (logCounter > 0) logCounter -= 1;
        else isEnabled = false;
    }

    public void SetCounter(int newCount)
    {
        if (logCounter == 0)
        {
            logCounter = newCount;
        }
    }

    public void SetLoopID(int id)
    {
        loopId = id;
    }

    public void Update(ComparisonOperator.Condition condition, object paramA, object paramB)
    {
        if (continuous) Check(paramA, paramB, condition);
        else if (isEnabled)
        {
            CountDown();
            Check(paramA, paramB, condition);
        } 
     
    }

    public void Check(object paramA, object paramB, ComparisonOperator.Condition condition)
    {
        if (compare.RunCondition(paramA, paramB, condition))
        {
            Debug.Log("True");
        }
        else Debug.Log("False");
        
    }

    public LoopDebugger(int _id, object _paramA, object _paramB, int _logCounter, int _maxIteration, bool _continuous, ComparisonOperator.Condition condition)
    {
        this.isEnabled = true;
        this.loopId = _id;
        this.continuous = _continuous;
        this.logCounter = _logCounter;
        this.MaxIteration = _maxIteration;
    }
}

