using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaichiAnimatorController : AnimatorController {

    const string onGuardAnimVar = "Guard";
    const string hittedAnimVar = "Hitted";
    const string downAnimVar = "Down";

    // Raise the guard
    public override void OnGuard()
    {
        animator.SetBool(onGuardAnimVar, true);
    }

    // Fall down to the earth
    public void GoDown()
    {
        animator.SetBool(downAnimVar, true);
    }

    // Fall down to the earth and do not get up
    public override void GoKO()
    {
        base.GoKO();
        animator.SetBool(downAnimVar, true);
    }

    // Get hitted by a simple attack
    public override void Hitted()
    {
        animator.SetBool(hittedAnimVar, true);
    }
        
}
