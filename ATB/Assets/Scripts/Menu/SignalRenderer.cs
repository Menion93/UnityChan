using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalRenderer : MonoBehaviour {

    public GameObject signal;

    Transform signalTrans;

    public Transform[] signalPosAlly;
    public Transform[] signalPosEnemy;

    void Start()
    {
        signalTrans = signal.transform;
    }

    public void RenderSignal(int currentPos, bool allySide)
    {
        if (signalTrans == null)
            signalTrans = signal.transform;

        signal.gameObject.SetActive(true);

        if (allySide)
        {
            signalTrans.position = signalPosAlly[currentPos].position;
            signalTrans.parent = signalPosAlly[currentPos];
        }
        else
        {
            signalTrans.position = signalPosEnemy[currentPos].position;
            signalTrans.parent = signalPosEnemy[currentPos];
        }
    }

    public void HideSignal(bool value)
    {
        signal.SetActive(!value);
    }

}
