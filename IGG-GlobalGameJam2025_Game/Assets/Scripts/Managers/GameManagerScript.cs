using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManagerScript : MonoBehaviour
{
    public float spawnPowerupsAfter = 10f;

    public Transform player1;
    public Transform player2;

    public GameObject redWinPanel;
    public GameObject yellowWinPanel;
    public GameObject tiePanel;

    public Transform[] spawnPowerUps;

    public GameObject[] powerUps;


    // Start is called before the first frame update
    void Start()
    {   

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
            redWinPanel.SetActive(false);
        }
        if(player2 == null)
        {
            redWinPanel.SetActive(true);
            yellowWinPanel.SetActive(false);
        }
        if(player1 == null && player2 == null)
        {
            tiePanel.SetActive(true);
        }

        //powerups
        StartCoroutine(SpawnPowerUps());
    }

    IEnumerator SpawnPowerUps()
    {
        int randomPowerUp = Random.Range(0, powerUps.Length);
        Transform pos = spawnPowerUps[Random.Range(0, spawnPowerUps.Length)];

        yield return new WaitForSeconds(spawnPowerupsAfter);
    }

    public void QuitToMenu()
    {
        Debug.Log("Hans hasn't made the main menu yet but go visit my itch page pls");
    }

    public void Rematch()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
