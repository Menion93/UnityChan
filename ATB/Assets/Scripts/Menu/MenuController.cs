using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

    public OptionSelection optionSelection;
    public AttackSelection attackSelection;
    public SubjectSelection subjectSelection;
    public TargetSelection targetSelection;

    AudioManager audioManager;

    enum StateSelection { Subject, Option, Attack, Target }
    StateSelection currentState;

    Stack<IATBMenu> history;
    public IATBMenu currentSelection { get; set; }

    ActionQueue allActionQueue;
    ActionQueue.ActionElement currentAction;

    public bool isInputEnabled { get; set; }

    void Awake()
    {
        allActionQueue = GetComponent<ActionQueue>();
        audioManager = GameObject.FindGameObjectWithTag(Tag.AudioManager).GetComponent<AudioManager>();
        isInputEnabled = true;
        subjectSelection.Initialize();
        currentSelection = subjectSelection;
        history = new Stack<IATBMenu>();
    }

	void Update ()
    {
        if(isInputEnabled)
        {
            currentSelection.ManageInput();

            if(Input.GetKeyDown(KeyCode.Backspace))
            {
                audioManager.failSound.Play();
            }
        }
    }

    public void GoToOptionSelection()
    {
        history.Push(currentSelection);
        currentSelection = optionSelection;
        currentSelection.Initialize();
    }

    public void GoToAttackSelection()
    {
        history.Push(currentSelection);

        ATBController currChar = subjectSelection.GetCharacterController();
        attackSelection.Initialize(currChar.moves, currChar);

        currentSelection = attackSelection;
    }

    public void GoToSpecialSelection()
    {
        history.Push(currentSelection);

        ATBController currChar = subjectSelection.GetCharacterController();
        attackSelection.Initialize(currChar.sMoves, currChar);

        currentSelection = attackSelection;
    }

    public void GoToPrevSelection()
    {
        currentSelection.Pause();
        currentSelection = history.Pop();
        currentSelection.Resume();
    }

    public void GoToSubjectSelection()
    {
        currentSelection = subjectSelection;
        subjectSelection.Initialize();
        history.Clear();
    }

    public void GoToTargetSelection()
    {
        currentSelection.Pause();
        history.Push(currentSelection);
        currentSelection = targetSelection;
        currentSelection.Initialize();
    }

    public void SetAction(ATBController owner, string action)
    {
        this.currentAction = new ActionQueue.ActionElement();
        currentAction.action = action;
        currentAction.subject = owner;
    }

    public void SetTarget(ATBController target)
    {
        currentAction.target = target;
        allActionQueue.Enqueue(currentAction);
        GoToSubjectSelection();
    }

    public ActionQueue GetActionQueue()
    {
        return allActionQueue;
    }
}
