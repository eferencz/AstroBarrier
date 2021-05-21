using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControllerScript : MonoBehaviour
{
    public GameObject CurrentLevel;
    public GameObject NextLevel;

    private float bulletsLeft;
    public float playerLevel;
    public bool levelLost = false;

    public MobileEnemyScript mobileEnemy1;
    public MobileEnemyScript mobileEnemy2;
    public MobileEnemyScript mobileEnemy3;

    public BulletCounterScript bulletCounter;
    public BulletCounterScript nextBulletCounter;

    public LifeCounterScript lifeCounter;

    public SpaceshipScript playerBullets;

    // Start is called before the first frame update
    void Start()
    {
        bulletsLeft = 5;
    }

    // Update is called once per frame
    void Update()
    {

        CheckForShoot();

        CheckForLivesLost();

        CheckForLevelLost();

    }

    void CheckForShoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (bulletsLeft > 0)
            {
                bulletsLeft += -1;
            }
        }

        if (bulletCounter.enemiesHit < 3)
        {
            if (bulletsLeft == 0)
            {
                levelLost = true;
            }
        }
    }

    void CheckForLivesLost()
    {
        lifeCounter.CheckLifeNumber();
    }

    void CheckForLevelLost()
    {
        if (levelLost == true)
        {
            Debug.Log("You Lost Level" + playerLevel + "!");

            lifeCounter.lifeNumber += -1;

            levelLost = false;

            bulletsLeft = 5;
        }
    }

    public void ResetLevel()
    {
        mobileEnemy1.ResetEnemy();
        mobileEnemy2.ResetEnemy();
        mobileEnemy3.ResetEnemy();

        levelLost = false;

        bulletsLeft = 5;

        playerBullets.ResetBullets();

        bulletCounter.enemiesHit = 0;

        bulletCounter.bulletNumber = 5;
    }

    public void MoveToNextLevel()
    {
        CurrentLevel.SetActive(false);
        NextLevel.SetActive(true);

        playerBullets.ResetBullets();

        nextBulletCounter.bulletNumber = 5;

        bulletCounter.CheckBulletNumber();
    }


}
