using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionSelection : Menu {

    const string empty = "";

	// Use this for initialization
	void Start () {
        Initialize();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Initialize()
    {

        fields = new MenuField[4];
        fields[0] = new AttackMenuField(controller);
        fields[1] = new MenuField(empty);
        fields[2] = new SpecialMenuField(controller);
        fields[3] = new QuitField();

        base.Initialize();

    }

    public override void ManageInput()
    {
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            controller.GoToPrevSelection();
            audioManager.backSound.Play();
        }
        else
        {
            base.ManageInput();
        }
    }

}
