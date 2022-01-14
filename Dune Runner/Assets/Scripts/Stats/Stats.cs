using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    #region variables
    [Header("Stat Properties")]
    public string statDisplayName;
    public float maxStat;
    public float minStat;
    public float statIncreaePerLevel;
    [Tooltip("The multiplier added from things like equipment and effects from potions")]
    public float statModifier;
    [HideInInspector]
    public float currentStat;
    #endregion

    #region Initialize
    void Start()
    {
        currentStat = maxStat;
    }
    #endregion

    #region Get Methods
    public float GetCurrent()
    {
        return currentStat;
    }

    public float GetMax()
    {
        return maxStat;
    }
    #endregion

    #region Set Methods
    public void SetCurrent(float value)
    {
        currentStat = value;
    }

    public void AddToCurrentStat(float value)
    {
        currentStat += value;
    }

    public void SetMax(float value)
    {
        maxStat = value;
    }
    #endregion

    #region Boolean Methods
    public bool HasStat(float stat)
    {
        if (stat > 0) return true;
        else return false;
    }

    public bool IsStatFull()
    {
        if (currentStat >= maxStat)
        {
            currentStat = maxStat;
            return true;
        }
        else return false;
    }
    #endregion

    #region Math Methods
    public void ModifyStat(float stat, float amount)
    {
        stat += amount;
    }
    #endregion
}

