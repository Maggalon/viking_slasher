using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    private float speed = 4f;
    private int positionOfPatrol = 5;
    public Transform point;
    private bool movingRight;

    void Start()
    {
        
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, point.position) < positionOfPatrol)
        {
            Chill();
        }
        
    }

    void Chill()
    {
        if (transform.position.x > point.position.x + positionOfPatrol)
        {
            movingRight = false;
        }
        else if (transform.position.x < point.position.x + positionOfPatrol)
        {
            movingRight = true;
        }

        if (movingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }

    void Angry()
    {

    }

    void GoBack()
    {

    }
}
