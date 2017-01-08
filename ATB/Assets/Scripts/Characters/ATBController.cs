using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATBController : MonoBehaviour {

    protected GameManager gameManager;
    protected AudioManager audioManager;

    public MenuController controller { get; set; }
    protected AnimatorController animController;
    public ATBController currentTarget { get; set; }
    
    public int maxAtbBarValue;
    bool actionInQueue = false;

    public float health;
    public float atbBar;

    protected string[] allMoves;

    public string[] moves { get; protected set; }
    public string[] sMoves { get; protected set; }

    public int[] indexMeleeMoves { get; protected set; }
    

    void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("Canvas").GetComponent<MenuController>();
        animController = GetComponent<AnimatorController>();
        gameManager = GameObject.FindGameObjectWithTag(Tag.GameManager).GetComponent<GameManager>();
        audioManager = GameObject.FindGameObjectWithTag(Tag.AudioManager).GetComponent<AudioManager>();

    }

    protected virtual void Update()
    {
        if(atbBar < maxAtbBarValue && !controller.GetActionQueue().isActionBeingAnimated())
        {
            atbBar += Time.deltaTime;

            if (atbBar > maxAtbBarValue)
            {
                atbBar = maxAtbBarValue;
            }
        }
    }

    public void PlayAction(string action, ATBController subject, ATBController target)
    {
        currentTarget = target;

        int indexOfMove = Array.IndexOf(allMoves, action);

        if (Array.IndexOf(indexMeleeMoves, indexOfMove) != -1)
        {
            animController.StartAttack(action, target.GetAnimatorController().ownPositionMelee, -0.5f);
        }
        else
        {
            animController.StartAttack(action, target.GetAnimatorController().ownPositionRanged, -0.5f);
        }

    }

    public bool CanAttack()
    {
        return atbBar >= maxAtbBarValue && health > 0 && !actionInQueue;
    }


    public virtual void Damage(int damage)
    {
        if (health == 0)
        {
            controller.GetActionQueue().isTargetActing = false;
            return;
        }

        this.health -= damage;


        if (health <= 0)
        {
            health = 0;
            animController.GoKO();
            controller.GetActionQueue().isTargetActing = false;
        }
        else
        {
            animController.Hitted();
        }

        audioManager.hit.Play();

    }

    public virtual void HeavyDamage(int damage)
    {
        if (health == 0)
        {
            controller.GetActionQueue().isTargetActing = false;
            return;
        }

        this.health -= damage;

        if (health <= 0)
        {
            health = 0;
            animController.GoKO();
            controller.GetActionQueue().isTargetActing = false;
        }
        else
        {
            animController.Hitted();
        }

        audioManager.hit.Play();

    }

    public void EmptyATBBar()
    {
        atbBar = 0;
    }

    public void isWaitingForActionToComplete(bool waiting)
    {
        actionInQueue = waiting;
    }

    public bool isWaitingForActionToComplete()
    {
        return actionInQueue;
    }

    public AnimatorController GetAnimatorController()
    {
        return animController;
    }

}
