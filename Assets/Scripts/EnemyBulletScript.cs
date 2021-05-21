using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBulletScript : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    public bool ShootDown = true;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (ShootDown == true)
        {
            rb.velocity = new Vector2(0, -speed);
        }
        else
        {
            rb.velocity = new Vector3(speed, 0);
        }

        //scoreText = GameObject.Find("ScoreText").GetComponent<Text>();


    }

    void Update()
    {
        if (Camera.main.WorldToViewportPoint(transform.position).y < 0)
        {
            //scoreText.GetComponent<score_controller>().score -= 5;
            //scoreText.GetComponent<score_controller>().UpdateScore();
            Destroy(this.gameObject);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerTag")
        {
            GameObject.Destroy(this.gameObject);
            //scoreText.GetComponent<score_controller>().score += 10;
            //scoreText.GetComponent<score_controller>().UpdateScore();
        }

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

        if (collision.gameObject.tag == "BulletTag")
        {
            GameObject.Destroy(this.gameObject);
            GameObject.Destroy(collision.gameObject);
        }


        if (collision.gameObject.tag == "EnemyBulletTag")
        {
            GameObject.Destroy(this.gameObject);
            GameObject.Destroy(collision.gameObject);
        }
    }
}
