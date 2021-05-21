using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCounterScript : MonoBehaviour
{

    public GameObject Life1;
    public GameObject Life2;
    public GameObject Life3;

    public float lifeNumber;

    public StartButtonScript restartGame;

    // Start is called before the first frame update
    void Start()
    {
        Life1.SetActive(false);
        Life2.SetActive(false);
        Life3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CheckLifeNumber();
    }

    public void CheckLifeNumber()
    {

        if (lifeNumber == 3)
        {
            Life1.SetActive(true);
            Life2.SetActive(true);
            Life3.SetActive(true);
        }

        if (lifeNumber == 2)
        {
            Life1.SetActive(true);
            Life2.SetActive(true);
            Life3.SetActive(false);
        }


        if (lifeNumber == 1)
        {
            Life1.SetActive(true);
            Life2.SetActive(false);
            Life3.SetActive(false);
        }


        if (lifeNumber <= 0)
        {
            Life1.SetActive(false);
            Life2.SetActive(false);
            Life3.SetActive(false);

            Debug.Log("Game Over");

            restartGame.StartingMenu();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyBulletTag")
        {
            lifeNumber += -1;
        }
    }
}