using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowActor : MonoBehaviour {

    public Transform actor;

    Transform trans;

	// Use this for initialization
	void Start () {
        trans = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        trans.position = actor.position;
    }
}
