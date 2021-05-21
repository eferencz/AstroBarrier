using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBulletScript : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    //private Text scoreText;

    public float enemiesHit;

    public bool levelPassed = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
        //scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    void Update()
    {
        if (Camera.main.WorldToViewportPoint(transform.position).y > 1)
        {
            //scoreText.GetComponent<score_controller>().score -= 5;
            //scoreText.GetComponent<score_controller>().UpdateScore();
            Destroy(this.gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyTag")
        {

            GameObject.Destroy(this.gameObject);
            //scoreText.GetComponent<score_controller>().score += 10;
            //scoreText.GetComponent<score_controller>().UpdateScore();
        }

        if (collision.gameObject.tag == "BarrierTag")
        {
            GameObject.Destroy(this.gameObject);
        }


        if (collision.gameObject.tag == "ShooterEnemyTag")
        {
            GameObject.Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "PlayerBulletTag")
        {
            GameObject.Destroy(this.gameObject);
        }
    }

}