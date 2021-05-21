using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButtonScript : MonoBehaviour
{

    public GameObject Level1;
    public GameObject Level2;
    public GameObject Level3;
    public GameObject Level4;

    public LevelControllerScript levelController1;
    public LevelControllerScript levelController2;
    public LevelControllerScript levelController3;
    public LevelControllerScript levelController4;

    public float levelNumber;

    public BulletCounterScript bulletCounter1;
    public BulletCounterScript bulletCounter2;
    public BulletCounterScript bulletCounter3;
    public BulletCounterScript bulletCounter4;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FindLevelNumber();
    }

    public void OnClick()
    {

        if (levelNumber == 1)
        {
            levelController1.ResetLevel();

            bulletCounter1.bulletNumber = 5;
        }

        if (levelNumber == 2)
        {
            levelController2.ResetLevel();

            bulletCounter2.bulletNumber = 5;
        }

        if (levelNumber == 3)
        {
            levelController3.ResetLevel();

            bulletCounter3.bulletNumber = 5;
        }

        if (levelNumber == 4)
        {
            levelController4.ResetLevel();

            bulletCounter4.bulletNumber = 5;
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
        }
    }
}
