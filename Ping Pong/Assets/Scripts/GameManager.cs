using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
    using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    bool isPlaying = false;
    bool gameEnd = false;
    bool didPlayerWin = false;
    public void SetPlayState()
    {
        isPlaying = true;
        gameEnd = false;
        ScoreKeeper.instance.enemyScore = -1;
        ScoreKeeper.instance.playerScore = -1;
        ScoreKeeper.instance.PlayerScore();
        ScoreKeeper.instance.EnemyScore();
    }
    public bool GetPlayState()
    {
        return isPlaying;
    }
    public void SetGameFinsihed(bool gameFinish, bool playerWonOrNot)
    {
        didPlayerWin = playerWonOrNot;
        gameEnd = gameFinish;
        if(gameEnd == true)
        {
            isPlaying = false;
        }
    }
    public bool GetWhoWon()
    {
        return didPlayerWin;
    }
    public bool GetGameEndState()
    {
        return gameEnd;
    }
    public void Quit()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
