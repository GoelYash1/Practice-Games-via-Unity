using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField]TextMeshProUGUI outcomeText;
    bool didPlayerWinTheMatch = false;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.GetGameEndState())
        {
            didPlayerWinTheMatch = gameManager.GetWhoWon();
            if(didPlayerWinTheMatch)
            {
                outcomeText.text = "Congrats!!\n You Won the match";
            }
            else
            {
                outcomeText.text = "You lost the match to your friend\n Better luck next time";
            }
        }
    }
}
