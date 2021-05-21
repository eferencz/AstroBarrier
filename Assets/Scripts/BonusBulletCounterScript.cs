using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBulletCounterScript : MonoBehaviour
{

    public float bulletNumber;

    public float enemiesHit;

    private bool levelPassed = false;

    public BonusLevelControllerScript bonusLevelController;
    public PlayerBulletScript playerBullet;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ShootBullet();

        CheckForWin();
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
        if (enemiesHit == 6)
        {
            levelPassed = true;

            enemiesHit = 0;
        }

        if (levelPassed == true)
        {

            levelPassed = false;
        }
    }
}

