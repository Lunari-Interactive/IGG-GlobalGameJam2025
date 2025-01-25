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

    public Transform player1;
    public Transform player2;

    public GameObject redWinPanel;
    public GameObject yellowWinPanel;

    public Transform[] spawnPowerUps;
    public GameObject[] powerUps;


    // Start is called before the first frame update
    void Start()
    {
        powerupsSpawned = powerupsActiveAtOnce;
        spawnpowerupsnextafter = spawnPowerupsNextAfter;

        player1 = GameObject.Find("Player1").GetComponent<Transform>();
        player2 = GameObject.Find("Player2").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //victory panel
        if(player1 == null)
        {
            yellowWinPanel.SetActive(true);
        }
        if(player2 == null)
        {
            redWinPanel.SetActive(true);
        }

        //powerups
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
