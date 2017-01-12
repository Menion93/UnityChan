using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAfterAttackBehavior : StateMachineBehaviour {

    AnimatorController animController;
    ATBController subject;

    Transform myTransform;

    public float delay;

    Vector3 startPosition;
    Vector3 finalPosition;

    bool tick;
    float alpha;

    const string idleAnimVar = "Idle";

    public float jumpTime;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        subject = animator.GetComponent<ATBController>();
        animController = animator.GetComponent<AnimatorController>();
        alpha = delay;
        startPosition = animController.transform.position;
        finalPosition = animController.startPosition;
        tick = true;
        myTransform = subject.transform;
    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(tick)
        {
            alpha += Time.deltaTime / jumpTime;
            myTransform.position = Vector3.Lerp(startPosition, finalPosition, alpha);

            if (alpha >= 1)
            {
                tick = false;
                animator.SetBool(idleAnimVar, true);
            }
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        subject.isWaitingForActionToComplete(false);
        subject.EmptyATBBar();
        subject.controller.GetActionQueue().SubjectFinishedActing();
    }
}
