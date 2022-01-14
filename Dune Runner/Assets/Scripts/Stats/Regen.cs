using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RegenStat : Stats
{
    [Tooltip("Amount stat will regen per update")]
    public float statRegen;
    [Tooltip("Amount of time regen is delayed by when not at max")]
    public float RegenDelay;
    private float regenCounter;

    public void resetRegenCounter()
    {
        regenCounter = RegenDelay;
    }

    public void SetRegenDelay(float value)
    {
        RegenDelay = value;
    }

    public void ModifyRegenDelay(float value)
    {
        RegenDelay += value;
    }

    public void checkRegenDelay()
    {
        if (regenCounter > 0)
        {
            regenCounter -= Time.deltaTime;
        }
        else regenCounter = 0;
    }

    public float StatRegen()
    {
        checkRegenDelay();
        if (regenCounter == 0) return statRegen;
        else return 0;
    }

    public void Update()
    {


    }

}

