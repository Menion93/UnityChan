using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaichiAIController : ATBController {

    const string flyingKick = "Flying Kick";
    const string highKick = "High Kick";
    const string knee = "Knee";
    const string punch = "Punch";

    const string shoryuken = "Shoryuken";
    const string hadoken = "Hadoken";

    TaichiAnimatorController taichiAnimController;

    void Start ()
    {
        moves = new string[4];
        moves[0] = flyingKick;
        moves[1] = highKick;
        moves[2] = knee;
        moves[3] = punch;

        sMoves = new string[2];
        sMoves[0] = shoryuken;
        sMoves[1] = hadoken;

        allMoves = new string[6];

        allMoves[0] = flyingKick;
        allMoves[1] = highKick;
        allMoves[2] = knee;
        allMoves[3] = punch;
        allMoves[4] = shoryuken;
        allMoves[5] = hadoken;

        indexMeleeMoves = new int[5];

        for (int i = 0; i < indexMeleeMoves.Length; ++i)
        {
            indexMeleeMoves[i] = i;
        }


        taichiAnimController = GetComponent<TaichiAnimatorController>();
	}

    protected override void Update()
    {

        if (atbBar < maxAtbBarValue && !controller.GetActionQueue().isActionBeingAnimated())
        {
            atbBar += Time.deltaTime;

            if (atbBar > maxAtbBarValue)
            {
                atbBar = maxAtbBarValue;
                float delay = UnityEngine.Random.Range(0, 20) / 10.0f;
                Invoke("AttackPlayer", delay);
            }
        }
    }

    public override void HeavyDamage(int damage)
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
            taichiAnimController.GoDown();
        }

        audioManager.hit.Play();

    }

    public void AttackPlayer()
    {
        if(!gameManager.gameIsEnded)
        {
            int indexMoves = UnityEngine.Random.Range(0, allMoves.Length - 1);
            controller.GetActionQueue().Enqueue(this, GetNextTarget(), allMoves[indexMoves]);
        }
        
    }

    ATBController GetNextTarget()
    {
        LinkedList<ATBController> liveAlly = new LinkedList<ATBController>();

        ATBController result = null;

        foreach (ATBController ally in gameManager.allyCharacters)
        {
            if (ally.health > 0)
                liveAlly.AddFirst(ally);
        }

        int offset = UnityEngine.Random.Range(0, liveAlly.Count - 1);
        
        while (offset >= 0)
        {
            if (offset == 0)
                result = liveAlly.First.Value;

            liveAlly.RemoveFirst();

            --offset;
        } 

        return result;
    }



}
