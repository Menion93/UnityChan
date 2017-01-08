using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATBControllerPlayer : ATBController {

    // Update is called once per frame
    protected override void Update()
    {
        if (atbBar < maxAtbBarValue && !controller.GetActionQueue().isActionBeingAnimated())
        {
            atbBar += Time.deltaTime;

            if (atbBar > maxAtbBarValue)
            {
                atbBar = maxAtbBarValue;
                if(!gameManager.gameIsEnded)
                    controller.subjectSelection.CharacterReady();
            }
        }
    }
}
