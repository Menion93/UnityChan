using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour {

    private UnityChanCharacter character;

    void Start()
    {
        character = GetComponent<UnityChanCharacter>();
    }

    // Update is called once per frame
    void Update ()
    {
        if(Input.GetKey(KeyCode.D))
        {
            character.MoveRight();
        }
        if(Input.GetKey(KeyCode.A))
        {
            character.MoveLeft();
        }
        if(Input.GetKey(KeyCode.W))
        {
            character.MoveForward();
        }
        if(Input.GetKey(KeyCode.S))
        {
            character.MoveBack();
        }
        if(Input.GetKey(KeyCode.Space))
        {
            character.Jump();
        }
        if(Input.GetKey(KeyCode.R))
        {
            character.Slide();
        }
        if(Input.GetKey(KeyCode.F))
        {
            character.Umato();
        }
    }
}
