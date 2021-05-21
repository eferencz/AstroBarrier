using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipScript : MonoBehaviour
{
    private float speed = 2;
    private Rigidbody2D rb;

    public GameObject bullet;

    public float bulletNumber = 5;

    public bool levelOver = false;

    public float levelNumber;

    public LevelControllerScript levelController1;
    public LevelControllerScript levelController2;
    public LevelControllerScript levelController3;

    public GameObject Level1;
    public GameObject Level2;
    public GameObject Level3;
    public GameObject Level4;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        BoundMovement();

        Shoot();

        CheckForLevelOver();

        FindLevelNumber();
    }

    void Shoot()
    {
        if (bulletNumber > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                bulletNumber += -1;
                GameObject.Instantiate(bullet, transform.position, transform.rotation);
            }
        }

        if (bulletNumber <= 0)
        {
            levelOver = true;
        }

    }

    void FindLevelNumber()
    {
        if (Level1.activeSelf)
        {
            levelNumber = 1;
        }

        if (Level2.activeSelf)
        {
            levelNumber = 2;
        }

        if (Level3.activeSelf)
        {
            levelNumber = 3;
        }

        if (Level4.activeSelf)
        {
            levelNumber = 4;
            bulletNumber = 100;
        }
    }


    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        float moveX = x * speed;
        float moveY = y * speed;

        rb.velocity = new Vector2(moveX, moveY);
    }

    void BoundMovement()
    {
        float dist = (this.transform.position - Camera.main.transform.position).z;

        float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
        float topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
        float bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;

        Vector3 playerSize = GetComponent<Renderer>().bounds.size;

        this.transform.position = new Vector3(
        Mathf.Clamp(this.transform.position.x, leftBorder + playerSize.x / 2, rightBorder - playerSize.x / 2),
        Mathf.Clamp(this.transform.position.y, topBorder + playerSize.y / 2, bottomBorder - playerSize.y / 2),
        this.transform.position.z
        );
    }

    void CheckForLevelOver()
    {
        if (bulletNumber <= 0)
        {
            levelOver = true;
        }
    }

    public void ResetBullets()
    {
        bulletNumber = 5;

        levelOver = false;
    }

}