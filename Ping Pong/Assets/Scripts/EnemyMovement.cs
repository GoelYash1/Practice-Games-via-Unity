using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float enemySpeed = 10f;
    [SerializeField] GameObject ball;
    GameManager gameManager;
    int playAgainstIndex = 0;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        playAgainstIndex = gameManager.GetCategoryIndex();
        if (gameManager.GetPlayState())
        {
            if(playAgainstIndex == 1)
            {
                float verticalInput = Input.GetAxis("Vertical2");
                transform.Translate(enemySpeed * Vector2.up * Time.deltaTime * verticalInput);
            }
            else if(playAgainstIndex == 0)
            {
                if(ball.transform.position.x > 0)                
                {
                    if (ball.transform.position.y > transform.position.y)
                    {
                        transform.Translate(Vector2.up * enemySpeed * Time.deltaTime);
                    }
                    else
                    {
                        transform.Translate(Vector2.down * enemySpeed * Time.deltaTime);
                    }
                }
                else
                {
                    if (transform.position.y > 0f)
                    {
                        transform.Translate(Vector2.down * enemySpeed * Time.deltaTime);
                    }
                    else if (transform.position.y < 0f)
                    {
                        transform.Translate(Vector2.up * enemySpeed * Time.deltaTime);
                    }
                }
            }
        }
    }
}
