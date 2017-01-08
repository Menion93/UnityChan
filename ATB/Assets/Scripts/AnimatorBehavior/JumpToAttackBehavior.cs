using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToAttackBehavior : StateMachineBehaviour {

    AnimatorController animController;

    Transform myTransform;

    Vector3 finalPosition;
    Vector3 startPosition;
    bool tick;
    float alpha;

    public float jumpTime;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animController = animator.GetComponent<AnimatorController>();
        alpha = animController.alpha;
        finalPosition = animController.enemyPosition.position;
        startPosition = animController.startPosition;
        myTransform = animController.transform;
        tick = true;
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
                animator.SetBool(animController.jumpToAttackAnimVar, false);
                animController.AnimatorSetBool(animController.selectedAttack, true);
            }
        }
    }

}
