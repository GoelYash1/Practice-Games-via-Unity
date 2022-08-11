using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] GameObject scoreCanvas;
    [SerializeField] GameObject centerLine;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject endScreen;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        mainMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.GetPlayState())
        {
            mainMenu.SetActive(false);
            centerLine.SetActive(true);
            scoreCanvas.SetActive(true);
            endScreen.SetActive(false);
        }
        if(gameManager.GetGameEndState())
        {
            mainMenu.SetActive(false);
            centerLine.SetActive(false);
            scoreCanvas.SetActive(false);
            endScreen.SetActive(true);
        }
        
    }
}
