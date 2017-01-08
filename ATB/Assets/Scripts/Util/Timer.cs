using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    public delegate void Del(string message);

    Del myDel;

    float countdown;
    float startTime;

    bool tick;

    string message;

    public void Initialize(Del del, float countdown, string message)
    {
        myDel = del;
        this.countdown = countdown;
        this.message = message;
    }

    public void StartTick()
    {
        tick = true;
        startTime = Time.time;
    }


	// Update is called once per frame
	void Update ()
    {
		if(tick && myDel != null && Time.time-startTime > countdown)
        {
            myDel(message);
            tick = false;
        }
	}
}
