using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class UImanager : MonoBehaviour
{
    private string levelToLoad;
    public AudioClip beep;

    void playBtnSound()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = beep;
        audio.Play();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3.0f);
    }

    public void PlayBtnClicked()
    {
        levelToLoad = "//our game";
        playBtnSound();
        StartCoroutine(Wait());
        SceneManager.LoadScene(levelToLoad);
    }
}
