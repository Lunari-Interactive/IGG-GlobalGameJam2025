using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using UnityEngine.Audio;

public class MainMenuManager : MonoBehaviour
{
    public AudioMixer AudioMixer;
    public Scene[] gameScenes;

    public GameObject mainMenu;
    public GameObject credits;

    public AudioClip[] mainMenuMusic;
    public AudioSource AudioSource;

    private void Update()
    {
        if(AudioSource.isPlaying != true)
        {
            int randomMusic = Random.Range(0, mainMenuMusic.Length);
            AudioSource.clip = mainMenuMusic[randomMusic];
            AudioSource.Play();
        }
        
    }

    public void Volume(float volume)
    {
        AudioMixer.SetFloat("volume", volume);
    }

    public void Play()
    {
        //int randomScene = Random.Range(0, gameScenes.Length);
        SceneManager.LoadScene(1);
    }

    public void QuitToDesktop()
    {
        Application.Quit();
    }

    public void Credits()
    {
        credits.SetActive(true);
    }

    public void BackFromCredits()
    {
        mainMenu.SetActive(true);
        credits.SetActive(false);
    }
}
