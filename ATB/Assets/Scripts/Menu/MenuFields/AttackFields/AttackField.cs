using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackField : MenuField {

    MenuController controller;

    ATBController owner;

    public AttackField(string action,  ATBController owner, MenuController controller) : base(action)
    {
        this.owner = owner;
        this.controller = controller;
    }

    public override void OnClick(AudioManager audioManager)
    {
        controller.SetAction(owner, text);
        controller.GoToTargetSelection();
        audioManager.selectSound.Play();
    }
}
