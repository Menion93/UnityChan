using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSelection : CharacterSelection
{

    public override void Initialize()
    {
        allySide = false;
        SetCurPosToFistEnemyCharacter();
        signalRenderer.RenderSignal(currentPos, allySide);
    }

    public override void ManageInput()
    {
        base.ManageInput();

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            controller.GoToPrevSelection();
            signalRenderer.HideSignal(true);
            audioManager.backSound.Play();
        }

    }

    protected override void ChooseCharacter()
    {
        if (allySide)
        {
            audioManager.failSound.Play();
            return;
        }
        signalRenderer.HideSignal(true);

        controller.SetTarget(gameManager.enemyCharacters[currentPos]);
        audioManager.selectSound.Play();
    }

    void SetCurPosToFistEnemyCharacter()
    {
        for (int i = gameManager.allyCharacters.Length-1; i >= 0; --i)
        {
            if (gameManager.enemyCharacters[i].health > 0)
            {
                currentPos = i;
                return;
            }
        }
    }
}
