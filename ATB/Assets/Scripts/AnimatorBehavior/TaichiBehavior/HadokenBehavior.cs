using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HadokenBehavior : StateMachineBehaviour {

    AudioManager audioManager;
    public GameObject HadokenProjectile;
    public int layer;

    ATBController enemy;

    public float offsetTimeHit;
    float timeOfStart;

    bool launched;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ATBController subject = animator.GetComponent<ATBController>();
        timeOfStart = Time.time;
        enemy = subject.currentTarget;
        enemy.GetAnimatorController().OnGuard();

        launched = false;

        if (offsetTimeHit < 0.3f)
            offsetTimeHit = 0.3f;

        audioManager = GameObject.FindGameObjectWithTag(Tag.AudioManager).GetComponent<AudioManager>();
        audioManager.hadoken.Play();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Time.time - timeOfStart > offsetTimeHit && !launched)
        {
            GameObject hadoken = Instantiate(HadokenProjectile, animator.transform.position + new Vector3(0,1.5f,0), Quaternion.identity);
            hadoken.transform.LookAt(enemy.transform.position + new Vector3(0, 1.5f, 0));
            hadoken.layer = layer;

            launched = true;
        }
    }

}
