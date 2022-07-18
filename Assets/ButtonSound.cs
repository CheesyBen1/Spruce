using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class ButtonSound : MonoBehaviour
{
    public AudioClip beep;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void playBtnSound()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = beep;
        audio.Play();
    }

    public void loadGame()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void loadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}