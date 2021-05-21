using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooterScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bullet;

    public GameObject shooter;

    public GameObject destroyedShooter;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject.Instantiate(bullet);
            }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BulletTag")
        {
            shooter.SetActive(false);
            destroyedShooter.SetActive(true);
        }

    }
}
