using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour
{
    [SerializeField] Transform topRacket, botttomRacket;

    float speed = 2f;
    float maxX = 3.75f, minX = -3.75f;

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);                   
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        if (objPosition.x > maxX)
        {
            objPosition.x = maxX;
        }
        if (objPosition.x < minX)
        {
            objPosition.x = minX;
        }

        objPosition.z = -1;

        objPosition.y = botttomRacket.position.y;
        botttomRacket.position = Vector3.Lerp(botttomRacket.position, objPosition, speed);

        objPosition.y = topRacket.position.y;
        topRacket.position = Vector3.Lerp(topRacket.position, objPosition, speed);
    }
}