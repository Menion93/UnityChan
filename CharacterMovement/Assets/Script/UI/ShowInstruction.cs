using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInstruction : MonoBehaviour {

    public GameObject instruction;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            instruction.active = true;
        }
        else
        {
            instruction.active = false;
        }
    }
}
