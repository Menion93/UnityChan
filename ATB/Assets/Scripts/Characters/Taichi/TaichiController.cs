using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaichiController : ATBControllerPlayer
{

    const string flyingKick = "Flying Kick";
    const string highKick = "High Kick";
    const string knee = "Knee";
    const string punch = "Punch";

    const string shoryuken = "Shoryuken";
    const string hadoken = "Hadoken";

    TaichiAnimatorController taichiAnimController;

	// Use this for initialization
	void Start () {

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

        for(int i = 0; i< indexMeleeMoves.Length; ++i)
        {
            indexMeleeMoves[i] = i;
        }

        taichiAnimController = GetComponent<TaichiAnimatorController>();

        atbBar = maxAtbBarValue;

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

}
