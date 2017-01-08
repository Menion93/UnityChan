using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialMenuField : MenuField {

    MenuController controller;

    const string special = "Special";

    public SpecialMenuField(MenuController controller) : base(special)
    {
        this.controller = controller;
    }

    public override void OnClick(AudioManager audioManager)
    {
        audioManager.selectSound.Play();
        controller.GoToSpecialSelection();
    }
}
