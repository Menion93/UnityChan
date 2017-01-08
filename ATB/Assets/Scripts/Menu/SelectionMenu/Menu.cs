using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Menu : MonoBehaviour, IATBMenu
{

    public MenuController controller;

    public Text[] textCells;
    public RectTransform[] cursorPos;
    public RectTransform cursorCurrentPos;

    public MenuField[] fields;

    public GameObject signalUp;
    public GameObject signalDown;

    protected AudioManager audioManager;

    int currentPos;
    int relPosition;

    // Use this for initialization
    void Awake ()
    {
        audioManager = GameObject.FindGameObjectWithTag(Tag.AudioManager).GetComponent<AudioManager> ();
    }
	
    public virtual void Initialize()
    {
        currentPos = 0;
        relPosition = 0;
        cursorCurrentPos.gameObject.SetActive(true);
        RenderFields();
        RenderCursor();
    }
    
    public virtual void ManageInput()
    {
        
        bool canGoUp = currentPos / 4.0f > 1;
        bool canGoDown = fields.Length - currentPos - 4 + relPosition > 0;

        // Render arrows up and down
        signalUp.SetActive(canGoUp);
        signalDown.SetActive(canGoDown);

        // Take the input
        if (Input.GetKeyDown(KeyCode.A))
            Left();
        else if (Input.GetKeyDown(KeyCode.D))
            Right();
        else if (Input.GetKeyDown(KeyCode.W))
            Up(canGoUp);
        else if (Input.GetKeyDown(KeyCode.S))
            Down(canGoDown);
        else if (Input.GetKeyDown(KeyCode.Return))
            SelectField();

    }

    void Left()
    {
        if (relPosition % 2 != 0)
        {
            --relPosition;
            --currentPos;

            RenderCursor();
            audioManager.moveSound.Play();
        }
    }

    void Right()
    {
        if (relPosition % 2 == 0)
        {
            ++relPosition;
            ++currentPos;

            RenderCursor();
            audioManager.moveSound.Play();
        }
    }

    void Up(bool canGoUp)
    {
        if(relPosition>1)
        {
            relPosition -= 2;
            currentPos -= 2;

            RenderCursor();
            audioManager.moveSound.Play();
        }
        else if(canGoUp)
        {
            relPosition += 2;
            currentPos -= 2;

            RenderCursor();
            RenderFields();
            audioManager.moveSound.Play();
        }
    }

    void Down(bool canGoDown)
    {
        if(relPosition<2)
        {
            relPosition += 2;
            currentPos += 2;

            RenderCursor();
            audioManager.moveSound.Play();
        }
        else if(canGoDown)
        {
            currentPos += 2;

            RenderFields();
            audioManager.moveSound.Play();
        }
    }

    void SelectField()
    {
        this.fields[currentPos].OnClick(audioManager);
    }

    protected void RenderFields()
    {
        for(int i = 0; i < textCells.Length; ++i)
        {
            textCells[i].text = fields[currentPos-relPosition + i].text;
        }
    }

    void RenderEmpty()
    {
        string empty = "";

        for (int i = 0; i < textCells.Length; ++i)
        {
            textCells[i].text = empty;
        }

        cursorCurrentPos.gameObject.SetActive(false);
    }

    void RenderCursor()
    {
        this.cursorCurrentPos.position = cursorPos[relPosition].position;
    }

    public void Resume()
    {
        Initialize();
    }

    public void Pause()
    {
        currentPos = 0;
        relPosition = 0;

        RenderEmpty();
    }
}
