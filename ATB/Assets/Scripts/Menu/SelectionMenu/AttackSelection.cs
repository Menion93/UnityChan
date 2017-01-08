using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSelection : Menu
{

    const string empty = "";

    string[] moves;
    ATBController owner;


    public override void Initialize()
    {

        int fieldsLen = moves.Length;

        if (moves.Length < 4)
        {
            fieldsLen = 4;
        }
        else if (moves.Length % 2 != 0)
        {
            ++fieldsLen;
        }

        fields = new MenuField[fieldsLen];

        int i;

        for (i = 0; i < moves.Length; ++i)
        {
            fields[i] = new AttackField(moves[i], owner, controller);
        }

        while (i < fieldsLen)
        {
            fields[i] = new MenuField(empty);
            ++i;
        }

        base.Initialize();

    }

    public void Initialize(string[] moves, ATBController owner)
    {
        this.moves = moves;
        this.owner = owner;

        Initialize();
    }

    public override void ManageInput()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
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
