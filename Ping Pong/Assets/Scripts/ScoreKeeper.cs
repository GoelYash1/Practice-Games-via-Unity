using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public static ScoreKeeper instance;
    GameManager gameManager;
    [SerializeField] Text playerScoreText;
    public int playerScore=0;
    [SerializeField] Text enemyScoreText;
    public int enemyScore=0;
    private void Start()
    {
        instance = this;
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        if(gameManager.GetPlayState())
        {
            if (playerScore == 11)
            {
                gameManager.SetGameFinsihed(true, true);
            }
            else if(enemyScore == 11)
            {
                gameManager.SetGameFinsihed(true, false);
            }
        }   
    }
    public void PlayerScore()
    {
        playerScore++;
        playerScoreText.text = playerScore.ToString();
    }
    public void EnemyScore()
    {
        enemyScore++;
        enemyScoreText.text = enemyScore.ToString();
    }
}
