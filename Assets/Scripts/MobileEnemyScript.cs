using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileEnemyScript : MonoBehaviour
{

    public List<WaypointScript2> Waypoints = new List<WaypointScript2>();

    public float runSpeed = 0.5f;
    public int DestinationWaypoint = 1;

    public float originalSpeed = 0.5f;

    private Vector3 Destination;
    private bool Forwards = true;

    private Renderer rend;
    [SerializeField]
    private Color colorToTurnTo = Color.red;
    private Color colorToReturnTo = Color.green;

    public BulletCounterScript bulletCounter;


    void Start()
    {
        this.Destination = this.Waypoints[DestinationWaypoint].transform.position;
    }


    void Update()
    {
        StopAllCoroutines();
        StartCoroutine(MoveTo());
    }


    IEnumerator MoveTo()
    {
        while ((transform.position - this.Destination).sqrMagnitude > 0.01f)
        {

            transform.position = Vector2.MoveTowards(transform.position,
                this.Destination, this.runSpeed * Time.deltaTime);
            yield return null;
        }

        if ((transform.position - this.Destination).sqrMagnitude <= 0.01f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {

        if (this.Waypoints[DestinationWaypoint].IsEndpoint)
        {
            if (this.Forwards)
                this.Forwards = false;
            else
                this.Forwards = true;
        }

        if (this.Forwards)
            ++DestinationWaypoint;
        else
            --DestinationWaypoint;

        if (DestinationWaypoint >= this.Waypoints.Count)
            DestinationWaypoint = 0;

        this.Destination = this.Waypoints[DestinationWaypoint].transform.position;
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

        runSpeed = 0f;
    }

    public void ResetEnemy()
    {

        rend = GetComponent<Renderer>();

        rend.material.color = colorToReturnTo;

        gameObject.tag = "EnemyTag";

        runSpeed = originalSpeed;
    }


}

