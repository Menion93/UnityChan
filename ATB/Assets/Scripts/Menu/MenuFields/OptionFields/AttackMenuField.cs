using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMenuField : MenuField
{
    MenuController controller;

    const string special = "Attack";

    public AttackMenuField(MenuController controller) : base(special)
    {
        this.controller = controller;
    }

    public override void OnClick(AudioManager audioManager)
    {
        controller.GoToAttackSelection();
        audioManager.selectSound.Play();
    }

}
