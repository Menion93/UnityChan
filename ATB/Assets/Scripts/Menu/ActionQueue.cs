using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionQueue : MonoBehaviour
{
    GameManager gameManager;
    MenuController controller;
    Queue<ActionElement> actionQuequeElem;

    public bool isSubjectActing { get; set; }
    public bool isTargetActing { get; set; }

    public struct ActionElement
    {
        public string action { get; set; }
        public ATBController subject { get; set; }
        public ATBController target { get; set; }

        public ActionElement(string action, ATBController subject, ATBController target)
        {
            this.action = action;
            this.subject = subject;
            this.target = target;
        }
    }

    void Awake()
    {
        controller = GetComponent<MenuController>();
        actionQuequeElem = new Queue<ActionElement>();
        gameManager = GameObject.FindGameObjectWithTag(Tag.GameManager).GetComponent<GameManager>();
    }

    void Update()
    {
        if (actionQuequeElem.Count != 0 && controller.isInputEnabled)
        {
            if (!isSubjectActing && !isTargetActing)
            {
                ActionElement cElem = actionQuequeElem.Dequeue();

                if (cElem.subject.health > 0)
                {
                    cElem.subject.PlayAction(cElem.action, cElem.subject, cElem.target);
                    isSubjectActing = true;
                    isTargetActing = true;
                }
                
            }
        }
    }

    public void Enqueue(ActionElement elem)
    {
        elem.subject.isWaitingForActionToComplete(true);
        actionQuequeElem.Enqueue(elem);
    }

    public void Enqueue(ATBController subject, ATBController target, string action)
    {
        ActionElement elem = new ActionElement();

        subject.isWaitingForActionToComplete(true);

        elem.subject = subject;
        elem.target = target;
        elem.action = action;

        actionQuequeElem.Enqueue(elem);
    }

    public bool isActionBeingAnimated()
    {
        return isSubjectActing || isTargetActing;
    }

    public void SubjectFinishedActing()
    {
        gameManager.CheckWinCondition();
        isSubjectActing = false;
    }
}
