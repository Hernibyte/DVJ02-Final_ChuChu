using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Timer
{
    public float time { get; set; }

    public bool CalcTime(float maxTime)
    {
        time += Time.deltaTime;
        if (time >= maxTime)
        {
            time = 0;
            return true;
        }
        return false;
    }
}
