using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{

    public Animator animator { get; set; }

    public Transform ownPositionMelee;
    public Transform ownPositionRanged;

    public Transform enemyPosition { get; set; }

    public Vector3 startPosition { get; set; }

    public string jumpToAttackAnimVar { get; private set; }
    public string jumpBackToIdleAnimVar { get; private set; }

    public string healthAnimVar { get; private set; }

    public float alpha { get; set; }

    public string selectedAttack { get; set; }

    // Use this for initialization
    void Awake()
    {
        animator = GetComponent<Animator>();
        startPosition = transform.position;

        jumpToAttackAnimVar = "JumpToAttack";
        jumpBackToIdleAnimVar = "BackAfterAttack";

        healthAnimVar = "Health";
}

    // Disable the bool variable in the next 4 frames (30fps)
    protected IEnumerator DisableBoolNextFrame(string animParameter)
    {
        yield return new WaitForSeconds(0.1f);

        animator.SetBool(animParameter, false);
    }

    // This method will set the animator parameter as true or false, if true then it will disactivate it next frame (33ms)
    public void AnimatorSetBool(string variabile, bool value)
    {
        animator.SetBool(variabile, value);

        if (value)
            StartCoroutine(DisableBoolNextFrame(variabile));
    }

    // Interface to start a melee attack
    public void StartAttack(string attack, Transform enemyPosition, float offset)
    {
        animator.SetBool(jumpToAttackAnimVar, true);
        selectedAttack = attack;
        this.enemyPosition = enemyPosition;

        // Set an offset to postpone the translation
        alpha = offset;
    }

    // Raise the guard
    public virtual void OnGuard()
    {
    }

    // The character is dead or KO
    public virtual void GoKO()
    {
        animator.SetFloat(healthAnimVar, 0);
    }

    // Get hitted by a simple attack
    public virtual void Hitted()
    {
    }

}
