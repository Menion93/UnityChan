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
        AnimatorSetBool(onGuardAnimVar, true);
    }

    // Fall down to the earth
    public void GoDown()
    {
        AnimatorSetBool(downAnimVar, true);
    }

    // Fall down to the earth and do not get up
    public override void GoKO()
    {
        base.GoKO();
        AnimatorSetBool(downAnimVar, true);
    }

    // Get hitted by a simple attack
    public override void Hitted()
    {
        AnimatorSetBool(hittedAnimVar, true);
    }
        
}
