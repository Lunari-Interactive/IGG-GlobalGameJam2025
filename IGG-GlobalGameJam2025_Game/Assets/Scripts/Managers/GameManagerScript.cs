using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using UnityEngine.Audio;

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

    public AudioClip[] gameMusic;
    public AudioSource musicPlayer;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPowerUps());
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
            redWinPanel.SetActive(false);
            yellowWinPanel.SetActive(false);
        }
        
        if(musicPlayer.isPlaying != true)
        {
            int randomMusic = Random.Range(0, gameMusic.Length);
            musicPlayer.clip = gameMusic[randomMusic];
            musicPlayer.Play();
        }

    }

    IEnumerator SpawnPowerUps()
    {
        while (true)
        {
            int randomPowerUp = Random.Range(0, powerUps.Length);
            Transform pos = spawnPowerUps[Random.Range(0, spawnPowerUps.Length)];
            Instantiate(powerUps[randomPowerUp], pos);

            yield return new WaitForSeconds(spawnPowerupsAfter);
        }
        
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Rematch()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
