using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carAnimEnd : MonoBehaviour
{
    public bool playerInteract = false;

    private Animator anim;
    private AudioSource audio;

    public AudioClip doorOpen;
    public AudioClip doorClose;

    private GameObject carCam;

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();

        carCam = GameObject.FindGameObjectWithTag("carCamera");
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerInteract)
        {
            textHint.textOn = true;
            textHint.Hint.text = "Press E to get out of car.";

            if (Input.GetButton("Interact"))
            {
                playerInteract = false;
                textHint.clearText();
                carCam.SetActive(false);

                playerStart.gameStart();

                audio.loop = false;
                audio.volume = 1;

                crosshairEnable.enable();

                audio.clip = doorOpen;

                audio.Play();
                audio.Stop();
            }
        }
    }

    public void carEnd()
    {
        playerInteract = true;
    }

    public void work()
    {
        textHint.textOn = true;
        textHint.Hint.text = "Getting sent out of town to work is such a hassle.";
    }

    public void work2()
    {
        textHint.Hint.text = "But I guess I shouldn't complain since it pays well.";
    }

    public void noText()
    {
        textHint.clearText();
    }

    public void petrol()
    {
        textHint.textOn = true;
        textHint.Hint.text = "Car's getting low on fuel, should stop by and refill.";
    }
}