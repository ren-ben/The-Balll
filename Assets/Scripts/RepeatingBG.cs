using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBG : MonoBehaviour
{
    public float speed = Obstacle.speed;

    public float endX;
    public float StartX;
    public float SpeedDecrement = 0.5f;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= endX)
        {
            Vector2 pos = new Vector2(StartX, transform.position.y);
            transform.position = pos;
        }
        speed = Obstacle.speed - SpeedDecrement;

    }
}
