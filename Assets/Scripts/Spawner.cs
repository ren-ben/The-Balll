using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;
    public float timeDecrease;
    public float minTime;
    public float SpeedIcrease = 0.5f;
    public float DefaultStartTimeBtwSpawns = 1.25f;
    public GameObject[] obstacleTemplate;

    private void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
    }

    private void Update()
    {
        if (timeBtwSpawns <= 0)
        {
            int rand = Random.Range(0, obstacleTemplate.Length);
            Instantiate(obstacleTemplate[rand], transform.position, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawns;

            if (startTimeBtwSpawns > minTime)
            {
                if (Controls.healthForSpawnerReset > 0)
                {
                    startTimeBtwSpawns -= timeDecrease;
                    Obstacle.speed = Obstacle.speed + SpeedIcrease;
                }
            }
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }

        if (Controls.healthForSpawnerReset <= 0)
        {
            Obstacle.speed = Obstacle.DefaultSpeed;
            startTimeBtwSpawns = DefaultStartTimeBtwSpawns;
            Controls.healthForSpawnerReset = Controls.DefaultHealth;
        }
    }
}
