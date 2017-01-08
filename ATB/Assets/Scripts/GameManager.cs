using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    const string thisScenePath = "Scene/taichiatb";

    public ATBController[] allyCharacters { get; set; }
    public ATBController[] enemyCharacters { get; set; }

    MenuController controller;
    AudioManager audioManager;
    PlayAgainCanvas playAgain;

    public bool gameIsEnded { get; set; }

    void Awake()
    {
        GameObject AllyLane = GameObject.FindGameObjectWithTag(Tag.AllyLane);
        GameObject EnemyLane = GameObject.FindGameObjectWithTag(Tag.EnemyLane);
        allyCharacters = AllyLane.GetComponentsInChildren<ATBController>();
        enemyCharacters = EnemyLane.GetComponentsInChildren<ATBController>();

        audioManager = GameObject.FindGameObjectWithTag(Tag.AudioManager).GetComponent<AudioManager>();
        audioManager.mainTheme.Play();

        GameObject canvas = GameObject.FindGameObjectWithTag(Tag.Canvas);
        controller = canvas.GetComponent<MenuController>();
        playAgain = canvas.GetComponent<PlayAgainCanvas>();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(thisScenePath, LoadSceneMode.Single);
    }

    public void CheckWinCondition()
    {
        bool allyWin = true;
        bool enemyWin = true;

        foreach(ATBController ally in allyCharacters)
        {
            if (ally.health > 0)
                enemyWin = false;
        }

        foreach(ATBController enemy in enemyCharacters)
        {
            if (enemy.health > 0)
                allyWin = false;
        }

        gameIsEnded = allyWin || enemyWin;
        
        if (allyWin && enemyWin)
            Draw();
        else if (enemyWin)
            EnemyWin();
        else if (allyWin)
            AllyWin();
    }

    void Draw()
    {
        controller.isInputEnabled = false;
        playAgain.ShowDraw();
    }

    void EnemyWin()
    {
        controller.isInputEnabled = false;
        playAgain.ShowEnemyWin();

    }

    void AllyWin()
    {
        controller.isInputEnabled = false;
        playAgain.ShowAllyWin();
    }
}
