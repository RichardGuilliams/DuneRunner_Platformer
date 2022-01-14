using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{

    public float currentTime;
    public bool countdownEnabled;
    

    public void Start()
    {

    }
    
    public void StartTimer(float startingTime)
    {
        currentTime = startingTime;
        countdownEnabled = true;
    }

    public void CountDone()
    {
        if (currentTime < 0)
        {
            Debug.Log("");
            currentTime = 0;
            countdownEnabled = false;
        }
    }

    public void Update()
    {
        if (countdownEnabled)
        {
            currentTime -= 1 * Time.deltaTime;
            Debug.Log(currentTime);
            CountDone();
        }
    }
}
