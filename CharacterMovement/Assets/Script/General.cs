using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class General : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        UnityEngine.Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Application.Quit();
        }
    }

}
