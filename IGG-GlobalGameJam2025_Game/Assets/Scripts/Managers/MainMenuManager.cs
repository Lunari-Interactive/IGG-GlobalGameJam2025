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

    public void Volume(float volume)
    {
        AudioMixer.SetFloat("volume", volume);
    }

    public void Play()
    {
        int randomScene = Random.Range(0, gameScenes.Length);
        SceneManager.LoadScene(randomScene);
    }

    public void QuitToDesktop()
    {
        Application.Quit();
    }
}
