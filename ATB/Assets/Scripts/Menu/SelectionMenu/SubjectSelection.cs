using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectSelection : CharacterSelection {

    bool isCharacterReady;

    void Start()
    {
        isCharacterReady = true;
        allySide = true;
    }

    public override void ManageInput()
    {
        if(isCharacterReady)
        {
            base.ManageInput();
        }
    }

    public void CharacterReady()
    {
        if (!isCharacterReady)
        {
            SetCurPosToFirstCharacter();
            signalRenderer.RenderSignal(currentPos, allySide);
            audioManager.selectSound.Play();
        }
    }

    protected override void ChooseCharacter()
    {
        if (!allySide || !gameManager.allyCharacters[currentPos].CanAttack())
        {
            audioManager.failSound.Play();
            return;
        }

        signalRenderer.HideSignal(true);
        controller.GoToOptionSelection();
        audioManager.selectSound.Play();
    }

    void SetCurPosToFirstCharacter()
    {
        isCharacterReady = false;

        for (int i = gameManager.allyCharacters.Length-1; i >= 0; --i)
        {
            if (gameManager.allyCharacters[i].CanAttack())
            {
                currentPos = i;
                isCharacterReady = true;
                return;
            }
        }
    }

    public override void Initialize()
    {
        if (signalRenderer == null)
            signalRenderer = GetComponent<SignalRenderer>();

        if (gameManager == null)
            gameManager = GameObject.FindGameObjectWithTag(Tag.GameManager).GetComponent<GameManager>();

        allySide = true;
        SetCurPosToFirstCharacter();

        if (isCharacterReady)
        {
           signalRenderer.RenderSignal(currentPos, allySide);
        }
    }

    public override void Resume()
    {
        allySide = true;
        signalRenderer.RenderSignal(currentPos, allySide);
    }

    public ATBController GetCharacterController()
    {
        return gameManager.allyCharacters[currentPos];
    }

}
