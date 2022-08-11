using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField]float moveSpeed = 5f;
    float verticalInput;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        if(gameManager.GetPlayState())
        {
            verticalInput = Input.GetAxis("Vertical2");
            transform.Translate(Vector2.up * Time.deltaTime * verticalInput * moveSpeed);
        }
    }
}
