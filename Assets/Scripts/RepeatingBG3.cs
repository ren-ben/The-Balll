using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBG3 : MonoBehaviour
{
    public float speed = Obstacle.speed;

    public float endX;
    public float StartX;
    public float SpeedDecrement = 2f;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= endX)
        {
            Vector2 pos = new Vector2(StartX, transform.position.y);
            transform.position = pos;
        }
        speed = Obstacle.speed - 3;

    }
}
