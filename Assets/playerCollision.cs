using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerCollision : MonoBehaviour
{
    public bool start = true;

    private float timer = 0;

    private static Behaviour playerScript;
    private CharacterController control;
    private static AudioSource ambient;
    private static Camera playerCam;
    private static AudioListener playerListen;
    private AudioSource SFX;

    private bool interact = false;

    //public int keyCount = 0;
    private bool key = false;

    private bool brownKey = false;
    private bool whiteKey = false;

    public int gasCount = 0;
    public int candleCount = 0;
    public int matchCount = 0;

    public GameObject key1;
    public GameObject key2;
    public GameObject key3;

    public AudioClip doorStuck;
    public AudioClip pickup;

    public GameObject candle1;
    public GameObject candle2;

    private bool intro = false;

    public bool brownOpen = false;
    public bool whiteOpen = false;

    // Start is called before the first frame update
    private void Start()
    {
        playerScript = (Behaviour)GameObject.FindWithTag("player").GetComponent("FirstPersonController");
        control = GetComponent<CharacterController>();
        ambient = GameObject.FindGameObjectWithTag("ambient").GetComponent<AudioSource>();
        //playerScript.enabled = false;
        playerCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        playerListen = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioListener>();
        SFX = GameObject.FindGameObjectWithTag("SFX").GetComponent<AudioSource>();

        candle1.SetActive(false);
        candle2.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        //anim.Play("Door_Open");
        //animator.SetBool("Open", false);
        //if (gameObject.tag == "door" && doorIsOpen == false)
        //{
        //    anim.Play("Door_Open");
        //    animator.SetBool("Open", true);
        //    doorIsOpen = false;
        //}

        if (!intro)
        {
            textHint.textOn = true;
            textHint.Hint.text = "Main entrance is locked. Looks like it takes 3 keys.";
            interact = true;
            SFX.clip = doorStuck;
            SFX.Play();
            intro = true;
        }

        RaycastHit hit;

        Debug.DrawRay(playerCam.transform.position, playerCam.transform.forward, Color.red);

        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, 5.0f))
        {
            if (hit.collider.gameObject.tag == "startDoor")
            {
                interactHint.textOn = true;

                if (Input.GetButton("Interact"))
                {
                    if (key == true)
                    {
                        timer = 0;
                        textHint.textOn = true;
                        textHint.Hint.text = "Locked. Takes 3 keys.";
                        interact = true;

                        SFX.clip = doorStuck;
                        SFX.Play();
                    }
                    else if (gasCount < 1)
                    {
                        timer = 0;
                        textHint.textOn = true;
                        textHint.Hint.text = "Can't leave. Still need to get fuel for my car.";
                        interact = true;
                    }
                    else
                    {
                        Debug.Log("WIN!");
                        playerScript.enabled = false;
                        SceneManager.LoadScene("WinningScene");
                    }
                }
            }
            else if (hit.collider.gameObject.tag == "secretDoor")
            {
                interactHint.textOn = true;
                if (Input.GetButton("Interact"))
                {
                    if (candleCount >= 2 && candleCount > 0)
                    {
                        Destroy(hit.collider.gameObject);
                        candle1.SetActive(true);
                        candle2.SetActive(true);
                    }
                    else
                    {
                        timer = 0;
                        textHint.textOn = true;
                        textHint.Hint.text = "\"The way shall show once two flames are lit.\"";
                        interact = true;
                    }
                }
            }
            else if (!brownOpen)
            {
                if (hit.collider.gameObject.tag == "brownDrawer")
                {
                    interactHint.textOn = true;
                    if (Input.GetButton("Interact"))
                    {
                        if (brownKey)
                        {
                            hit.collider.gameObject.GetComponent<Animation>().Play("drawerOpenBrown");
                            brownOpen = true;
                        }
                        else
                        {
                            timer = 0;
                            textHint.textOn = true;
                            textHint.Hint.text = "Locked, needs a key.";
                            interact = true;
                        }
                    }
                }
            }
            else if (!whiteOpen)
            {
                if (hit.collider.gameObject.tag == "whiteDrawer")
                {
                    interactHint.textOn = true;
                    if (Input.GetButton("Interact"))
                    {
                        if (brownKey)
                        {
                            hit.collider.gameObject.GetComponent<Animation>().Play("drawerOpen");
                            brownOpen = true;
                        }
                        else
                        {
                            timer = 0;
                            textHint.textOn = true;
                            textHint.Hint.text = "Locked, needs a key.";
                            interact = true;
                        }
                    }
                }
            }
            else if (hit.collider.gameObject.tag == "candle")
            {
                if (Input.GetButton("Interact"))
                {
                    candleGUI.candle++;
                    candleCount++;
                    Destroy(hit.collider.gameObject);
                    if (candleCount == 1)
                    {
                        timer = 0;
                        textHint.textOn = true;
                        textHint.Hint.text = "Seems useful. I'll hold on to it.";
                        interact = true;
                    }
                    else if (candleCount == 2)
                    {
                        timer = 0;
                        textHint.textOn = true;
                        textHint.Hint.text = "Another one. Must be used here.";
                        interact = true;
                    }
                    playPickup();
                }
            }
            else
            {
                interactHint.textOn = false;
            }
        }
        else
        {
            interactHint.textOn = false;
        }

        if (interact)
        {
            timer += Time.deltaTime;
            if (timer > 3)
            {
                textHint.clearText();
                timer = 0;
                interact = false;
            }
        }
    }

    private void playPickup()
    {
        SFX.clip = pickup;
        SFX.Play();
    }

    private void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "enemy")
        {
            Debug.Log("lose");
            playerScript.enabled = false;
            SceneManager.LoadScene("GameOverScene");
        }
        //if (collisionInfo.gameObject.tag == "key")
        //{
        //    keyCount++;
        //    if (keyCount == 1)
        //    {
        //        key1.GetComponent<RawImage>().enabled = true;
        //        timer = 0;
        //        textHint.textOn = true;
        //        textHint.Hint.text = "First key. Need 2 more.";
        //        interact = true;
        //    }
        //    if (keyCount == 2)
        //    {
        //        key2.GetComponent<RawImage>().enabled = true;
        //        timer = 0;
        //        textHint.textOn = true;
        //        textHint.Hint.text = "Second key. Need 1 more.";
        //        interact = true;
        //    }
        //    if (keyCount == 3)
        //    {
        //        key3.GetComponent<RawImage>().enabled = true;
        //        timer = 0;
        //        textHint.textOn = true;
        //        textHint.Hint.text = "Third key. I could escape if I have fuel for my car.";
        //        interact = true;
        //    }
        //    Destroy(collisionInfo.gameObject);
        //    playPickup();
        //}

        if (collisionInfo.gameObject.tag == "brownKey")
        {
            brownKey = true;
            Destroy(collisionInfo.gameObject);
            timer = 0;
            textHint.textOn = true;
            textHint.Hint.text = "A key labelled with brown.";
            interact = true;
            playPickup();
        }

        if (collisionInfo.gameObject.tag == "whiteKey")
        {
            whiteKey = true;
            Destroy(collisionInfo.gameObject);
            timer = 0;
            textHint.textOn = true;
            textHint.Hint.text = "A key labelled with white.";
            interact = true;
            playPickup();
        }

        if (collisionInfo.gameObject.tag == "gas")
        {
            gasGUI.gas++;
            gasCount++;
            Destroy(collisionInfo.gameObject);
            timer = 0;
            textHint.textOn = true;
            textHint.Hint.text = "Nice. Got fuel for my car.";
            interact = true;
            playPickup();
        }

        //if (collisionInfo.gameObject.tag == "candle")
        //{
        //    candleGUI.candle++;
        //    candleCount++;
        //    Destroy(collisionInfo.gameObject);
        //    if (candleCount == 1)
        //    {
        //        timer = 0;
        //        textHint.textOn = true;
        //        textHint.Hint.text = "Seems useful. I'll hold on to it.";
        //        interact = true;
        //    }
        //    else if (candleCount == 2)
        //    {
        //        timer = 0;
        //        textHint.textOn = true;
        //        textHint.Hint.text = "Another one. Must be used here.";
        //        interact = true;
        //    }
        //    playPickup();
        //}

        if (collisionInfo.gameObject.tag == "matches")
        {
            matchGUI.matches++;
            Destroy(collisionInfo.gameObject);
            timer = 0;
            textHint.textOn = true;
            textHint.Hint.text = "Could light something.";
            interact = true;
            playPickup();
        }
    }
}