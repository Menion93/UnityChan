using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttackBehavior : StateMachineBehaviour {

    AudioManager audioManager;

    ATBController enemy;

    public float offsetTimeHit;
    float timeOfStart;

    bool hitted;

    public int damage;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ATBController subject = animator.GetComponent<ATBController>();
        timeOfStart = Time.time;
        enemy = subject.currentTarget;
        enemy.GetAnimatorController().OnGuard();
        hitted = false;

        if (offsetTimeHit < 0.3f)
            offsetTimeHit = 0.3f;

        if(!audioManager)
            audioManager = GameObject.FindGameObjectWithTag(Tag.AudioManager).GetComponent<AudioManager>();

        audioManager.haa.Play();
    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
	    if(Time.time-timeOfStart>offsetTimeHit && !hitted)
        {
            hitted = true;
            enemy.Damage(damage);
        }
	}

}
