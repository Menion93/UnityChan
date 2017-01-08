using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayAgainCanvas : MonoBehaviour {

    public GameObject playAgainCanvas;

    const string AllyWin = "You Win!";
    const string EnemyWin = "Enemy Win!";
    const string Draw = "Draw!";

    public void ShowAllyWin()
    {
        playAgainCanvas.SetActive(true);

        Text text = playAgainCanvas.transform.GetChild(0).GetComponent<Text>();
        text.text = AllyWin;
    }

    public void ShowEnemyWin()
    {
        playAgainCanvas.SetActive(true);

        Text text = playAgainCanvas.transform.GetChild(0).GetComponent<Text>();
        text.text = AllyWin;

        text.text = EnemyWin;
    }

    public void ShowDraw()
    {
        playAgainCanvas.SetActive(true);

        Text text = playAgainCanvas.transform.GetChild(0).GetComponent<Text>();
        text.text = AllyWin;

        text.text = Draw;
    }

    public void HidePlayAgainCanvas()
    {
        playAgainCanvas.SetActive(false);
    }


}
