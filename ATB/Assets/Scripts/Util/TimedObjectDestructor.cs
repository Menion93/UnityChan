using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedObjectDestructor : MonoBehaviour {

    public float timeToDestroy;

    float startTime;

	// Use this for initialization
	void Start ()
    {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Time.time - startTime > timeToDestroy)
        {
            Destroy(this.gameObject);
        }
    }
}
