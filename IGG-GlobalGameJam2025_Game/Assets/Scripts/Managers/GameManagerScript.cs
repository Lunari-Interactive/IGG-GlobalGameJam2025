using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManagerScript : MonoBehaviour
{
    public float spawnPowerupsAfter = 10f;

    public float spawnPowerupsNextAfter = 30f;
    float spawnpowerupsnextafter;
    public int powerupsActiveAtOnce = 3;
    int powerupsSpawned;

    public Transform[] spawnPowerUps;
    public GameObject[] powerUps;


    // Start is called before the first frame update
    void Start()
    {
        powerupsSpawned = powerupsActiveAtOnce;
        spawnpowerupsnextafter = spawnPowerupsNextAfter;
    }

    // Update is called once per frame
    void Update()
    {
        spawnPowerupsAfter--;

        if(spawnPowerupsAfter <= 0 && powerupsActiveAtOnce > 0)
        {
            SpawnPowerups();
            powerupsActiveAtOnce--;
        }
        if(spawnPowerupsAfter >= 0) { spawnPowerupsNextAfter--; }
        if (spawnPowerupsNextAfter <= 0 && powerupsActiveAtOnce > 0)
        {
            SpawnPowerups();
            powerupsActiveAtOnce--;
            spawnPowerupsNextAfter = spawnpowerupsnextafter;
        }
        if (powerupsActiveAtOnce >= 0) { powerupsActiveAtOnce = 3; }
    }

    void SpawnPowerups()
    {
        GameObject randPowerUp = powerUps[Random.Range(0,powerUps.Length)];

        Transform randTransform = spawnPowerUps[Random.Range(0, spawnPowerUps.Length)];
        Instantiate(randPowerUp, randTransform);
    }
}
