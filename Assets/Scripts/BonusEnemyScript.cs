using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusEnemyScript : MonoBehaviour
{
    private float speed = 2;

    private float originalSpeed = 2;

    private Rigidbody2D rb;

    private Renderer rend;
    [SerializeField]
    private Color colorToTurnTo = Color.red;
    private Color colorToReturnTo = Color.green;

    public BonusBulletCounterScript bulletCounter;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        float moveX = x * -speed;
        float moveY = y * -speed;

        rb.velocity = new Vector2(moveX, moveY);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.gameObject.tag == "EnemyTag")
        {
            if (collision.gameObject.tag == "BulletTag")
            {
                ChangeColor();

                bulletCounter.AddToScore();
            }

            if (collision.gameObject.tag == "EnemyBulletTag")
            {
                ChangeColor();

                bulletCounter.AddToScore();
            }
        }
    }

    void ChangeColor()
    {
        rend = GetComponent<Renderer>();

        rend.material.color = colorToTurnTo;

        gameObject.tag = "BarrierTag";

        speed = 0f;
    }

    public void ResetEnemy()
    {

        rend = GetComponent<Renderer>();

        rend.material.color = colorToReturnTo;

        gameObject.tag = "EnemyTag";

        speed = originalSpeed;
    }
}
