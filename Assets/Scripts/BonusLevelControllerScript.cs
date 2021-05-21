using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusLevelControllerScript : MonoBehaviour
{
    public GameObject CurrentLevel;
    public GameObject NextLevel;

    private float bulletsLeft;
    public float playerLevel;
    public bool levelLost = false;

    public BonusEnemyScript bonusEnemy1;
    public BonusEnemyScript bonusEnemy2;
    public BonusEnemyScript bonusEnemy3;
    public BonusEnemyScript bonusEnemy4;
    public BonusEnemyScript bonusEnemy5;
    public BonusEnemyScript bonusEnemy6;

    public BonusBulletCounterScript bulletCounter;
    public BonusBulletCounterScript nextBulletCounter;

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

        if (bulletCounter.enemiesHit < 6)
        {
            if (bulletsLeft == 0)
            {
                levelLost = true;
            }
        }
    }

    void CheckForLevelLost()
    {
        if (levelLost == true)
        {

            levelLost = false;

            bulletsLeft = 100;
        }
    }

    public void ResetLevel()
    {
        bonusEnemy1.ResetEnemy();
        bonusEnemy2.ResetEnemy();
        bonusEnemy3.ResetEnemy();
        bonusEnemy4.ResetEnemy();
        bonusEnemy5.ResetEnemy();
        bonusEnemy6.ResetEnemy();

        levelLost = false;

        bulletsLeft = 100;

        playerBullets.ResetBullets();

        bulletCounter.enemiesHit = 0;

        bulletCounter.bulletNumber = 100;
    }


}