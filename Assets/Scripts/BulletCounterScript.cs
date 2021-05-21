using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCounterScript : MonoBehaviour
{

    public GameObject Bullet1;
    public GameObject Bullet2;
    public GameObject Bullet3;
    public GameObject Bullet4;
    public GameObject Bullet5;

    public float bulletNumber;

    public float enemiesHit;

    private bool levelPassed = false;

    public LevelControllerScript levelController;
    public PlayerBulletScript playerBullet;

    // Start is called before the first frame update
    void Start()
    {
        Bullet1.SetActive(false);
        Bullet2.SetActive(false);
        Bullet3.SetActive(false);
        Bullet4.SetActive(false);
        Bullet5.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CheckBulletNumber();
        ShootBullet();

        CheckForWin();
    }

    public void CheckBulletNumber()
    {
        if (bulletNumber == 5)
        {
            Bullet1.SetActive(true);
            Bullet2.SetActive(true);
            Bullet3.SetActive(true);
            Bullet4.SetActive(true);
            Bullet5.SetActive(true);
        }

        if (bulletNumber == 4)
        {
            Bullet1.SetActive(true);
            Bullet2.SetActive(true);
            Bullet3.SetActive(true);
            Bullet4.SetActive(true);
            Bullet5.SetActive(false);
        }

        if (bulletNumber == 3)
        {
            Bullet1.SetActive(true);
            Bullet2.SetActive(true);
            Bullet3.SetActive(true);
            Bullet4.SetActive(false);
            Bullet5.SetActive(false);
        }

        if (bulletNumber == 2)
        {
            Bullet1.SetActive(true);
            Bullet2.SetActive(true);
            Bullet3.SetActive(false);
            Bullet4.SetActive(false);
            Bullet5.SetActive(false);
        }


        if (bulletNumber == 1)
        {
            Bullet1.SetActive(true);
            Bullet2.SetActive(false);
            Bullet3.SetActive(false);
            Bullet4.SetActive(false);
            Bullet5.SetActive(false);
        }


        if (bulletNumber <= 0)
        {
            Bullet1.SetActive(false);
            Bullet2.SetActive(false);
            Bullet3.SetActive(false);
            Bullet4.SetActive(false);
            Bullet5.SetActive(false);
        }

    }

    private void ShootBullet()
    {
        if (bulletNumber > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                bulletNumber += -1;
            }
        }
    }

    public void AddToScore()
    {
        enemiesHit += 1;
    }

    public void CheckForWin()
    {
        if (enemiesHit == 3)
        {
            levelPassed = true;

            enemiesHit = 0;
        }

        if (levelPassed == true)
        {
            levelController.MoveToNextLevel();

            levelPassed = false;
        }
    }
}
