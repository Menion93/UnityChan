using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitField : MenuField
{
    const string quit = "Quit Game";

    public QuitField() : base(quit) { }

    public override void OnClick(AudioManager audioManager)
    {
        audioManager.selectSound.Play();
        Application.Quit();

    }
}
