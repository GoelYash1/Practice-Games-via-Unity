using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float enemySpeed = 10f;
    GameManager gameManager;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        if (gameManager.GetPlayState())
        {
            float verticalInput = Input.GetAxis("Vertical");
            transform.Translate(enemySpeed * Vector2.up * Time.deltaTime * verticalInput);
        }
    }
}
