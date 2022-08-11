using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] float xMovement;
    [SerializeField] float yMovement;
    [SerializeField] float maxXSpeed = 15f;
    [SerializeField] float minXSpeed = 5f;
    [SerializeField] float maxYSpeed = 10f;
    [SerializeField] float minYSpeed = 5f;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        xMovement = Random.Range(minXSpeed, maxXSpeed);
        yMovement = Random.Range(minYSpeed, maxYSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.GetPlayState())
        {
            StartCoroutine(WaitToBeginGame());
            Move();
        }
    }
    void Move()
    {
        transform.Translate(Vector2.left * xMovement * Time.deltaTime);
        transform.Translate(Vector2.up * yMovement * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("collisionBox") || collision.gameObject.CompareTag("EnemyUp") || collision.gameObject.CompareTag("EnemyDown") || collision.gameObject.CompareTag("PlayerUp") || collision.gameObject.CompareTag("PlayerDown"))
        {
            yMovement = -yMovement;
        }
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            xMovement = -xMovement;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PlayerGoal"))
        {
            ScoreKeeper.instance.EnemyScore();
            transform.position = new Vector3(FindObjectOfType<EnemyMovement>().gameObject.transform.position.x - 1f,0,0);
            StartCoroutine(WaitToBeginGame());
            xMovement = Random.Range(minXSpeed, maxXSpeed);
            yMovement = Random.Range(minYSpeed, maxYSpeed);
        }
        if(collision.gameObject.CompareTag("EnemyGoal"))
        {
            ScoreKeeper.instance.PlayerScore();
            transform.position = new Vector3(FindObjectOfType<PlayerMovement>().gameObject.transform.position.x + 1f , 0 ,0);
            StartCoroutine(WaitToBeginGame());
            xMovement = Random.Range(-maxXSpeed, -minXSpeed);
            yMovement = Random.Range(minYSpeed, maxYSpeed);
        }
        
    }
    IEnumerator WaitToBeginGame()
    {
        yield return new WaitForSeconds(0.2f);
    }
}
