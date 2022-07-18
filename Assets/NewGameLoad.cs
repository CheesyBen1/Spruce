using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class NewGameLoad : MonoBehaviour
{
    [Header("Levels to Load")]
    public string newGameLevel;

    private string levelToLoad;
    public AudioClip beep;

    public void playBtnSound()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = beep;
        audio.Play();
        GameObject background = GameObject.Find("BackgroundMusic");
        background.SetActive(false);
    }

    public void NewDialogueYes()
    {
        playBtnSound();
        SceneManager.LoadScene(newGameLevel);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}