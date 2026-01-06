using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform PlayerPaddle;
    public Transform EnemyPaddle;

    public int playerScore = 0;
    public int enemyScore = 0;

    public TextMeshProUGUI textPointsPlayer;
    public TextMeshProUGUI textPointsEnemy;

    public BallController ballController;

    public int winPoints = 6;

    public GameObject screenEndGame;
    public TextMeshProUGUI textEndGame;

    public void CheckWin() 
    { 
        if (enemyScore >= winPoints || playerScore >= winPoints) 
        {
            //ResetGame();
            EndGame();
        } 
    }

    public void ScorePlayer() 
    { 
        playerScore++; 
        textPointsPlayer.text = playerScore.ToString();
        CheckWin();
    }
    public void ScoreEnemy()
    {
        enemyScore++;
        textPointsEnemy.text = enemyScore.ToString();
        CheckWin();

    }

    public void EndGame()
    {
        screenEndGame.SetActive(true);
        string winner = SaveController.Instance.GetName(playerScore > enemyScore);
        textEndGame.text = "Vitória " + winner;
        SaveController.Instance.SaveWinner(winner);
        Invoke("LoadMenu", 2f);
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }


    // Start is called before the first frame update
    void Start()
    {
        ResetGame();
    }

    public void ResetGame()
    {
        PlayerPaddle.position = new Vector3(-20f, 0f, 0f);
        EnemyPaddle.position = new Vector3(20f, 0f, 0f);

        ballController.ResetBall();

        playerScore = 0;
        enemyScore = 0;

        textPointsEnemy.text = enemyScore.ToString();
        textPointsPlayer.text = playerScore.ToString();
    }

}
