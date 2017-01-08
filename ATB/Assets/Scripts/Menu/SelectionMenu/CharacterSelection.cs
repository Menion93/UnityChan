using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterSelection : MonoBehaviour, IATBMenu
{
    protected MenuController controller;
    protected GameManager gameManager;
    protected AudioManager audioManager;
    protected SignalRenderer signalRenderer;

    protected int currentPos;
    protected bool allySide;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag(Tag.AudioManager).GetComponent<AudioManager>();
        controller = GameObject.FindGameObjectWithTag(Tag.Canvas).GetComponent<MenuController>();
        gameManager = GameObject.FindGameObjectWithTag(Tag.GameManager).GetComponent<GameManager>();
        signalRenderer = GetComponent<SignalRenderer>();
    }

    public virtual void ManageInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
            Left();
        else if (Input.GetKeyDown(KeyCode.D))
            Right();
        else if (Input.GetKeyDown(KeyCode.W))
            Up();
        else if (Input.GetKeyDown(KeyCode.S))
            Down();
        else if (Input.GetKeyDown(KeyCode.Return))
            ChooseCharacter();
    }

    void Left()
    {
        if(allySide)
        {
            allySide = false;

            if(currentPos >= gameManager.enemyCharacters.Length)
            {
                currentPos = gameManager.enemyCharacters.Length - 1;
            }

            signalRenderer.RenderSignal(currentPos, allySide);
            audioManager.moveSound.Play();
        }
    }

    void Right()
    {
        if (!allySide)
        {
            allySide = true;

            if (currentPos >= gameManager.allyCharacters.Length)
            {
                currentPos = gameManager.allyCharacters.Length - 1;
            }

            signalRenderer.RenderSignal(currentPos, allySide);
            audioManager.moveSound.Play();
        }
    }

    void Up()
    {
        ++currentPos;

        if (allySide)
        {
            if(currentPos >= gameManager.allyCharacters.Length)
            {
                currentPos = gameManager.allyCharacters.Length - 1;
                return;
            }
        }
        else
        {
            if (currentPos >= gameManager.enemyCharacters.Length)
            {
                currentPos = gameManager.allyCharacters.Length - 1;
                return;
            }
        }

        signalRenderer.RenderSignal(currentPos, allySide);
        audioManager.moveSound.Play();
    }

    void Down()
    {
        --currentPos;

        if (currentPos < 0)
        {
            currentPos = 0;
            return;
        }

        signalRenderer.RenderSignal(currentPos, allySide);
        audioManager.moveSound.Play();
    }

    protected abstract void ChooseCharacter();

    public virtual void Pause() { }
    public virtual void Resume() { }
    public virtual void Initialize() { }
}
