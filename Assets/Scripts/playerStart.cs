using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerStart : MonoBehaviour
{
    public bool start = false;

    public bool game = false;

    private float timer = 0;

    private bool boundaryHit = false;

    private static bool tutorial = false;

    private static Behaviour playerScript;
    private CharacterController control;
    private static AudioSource ambient;
    private static Camera playerCam;
    private static AudioListener playerListen;
    private AudioSource SFX;
    private GameObject rain;

    public GameObject paper;
    private bool paperSpawn = false;

    private bool hasKey = false;

    private bool interact = false;

    public AudioClip doorStuck;
    public AudioClip doorOpen;
    public AudioClip kioskStuck;

    public AudioClip raining;

    // Start is called before the first frame update
    private void Start()
    {
        playerScript = (Behaviour)GameObject.FindWithTag("player").GetComponent("FirstPersonController");
        control = GetComponent<CharacterController>();
        ambient = GameObject.FindGameObjectWithTag("ambient").GetComponent<AudioSource>();
        playerScript.enabled = false;
        playerCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        playerListen = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioListener>();
        SFX = GameObject.FindGameObjectWithTag("SFX").GetComponent<AudioSource>();
        rain = GameObject.FindGameObjectWithTag("rain");

        GameObject.FindGameObjectWithTag("blackScreen").GetComponent<Image>().color = new Color(0, 0, 0, 0);

        rain.SetActive(false);
        playerCam.enabled = start;
        playerListen.enabled = start;
    }

    private GameObject paperClone;

    // Update is called once per frame
    private void Update()
    {
        RaycastHit hit;

        Debug.DrawRay(playerCam.transform.position, playerCam.transform.forward, Color.red);

        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, 5.0f))
        {
            if (hit.collider.gameObject.tag == "kiosk")
            {
                interactHint.textOn = true;
                if (!interact)
                {
                    if (Input.GetButton("Interact"))
                    {
                        textHint.textOn = true;
                        textHint.Hint.text = "It's stuck. Maybe I should try looking in the shop.";

                        SFX.clip = kioskStuck;
                        SFX.Play();

                        interact = true;
                    }
                }
            }
            else

            if (hit.collider.gameObject.tag == "stationDoor")
            {
                interactHint.textOn = true;
                if (!interact)
                {
                    if (Input.GetButton("Interact"))
                    {
                        textHint.textOn = true;
                        textHint.Hint.text = "The door seems to also be stuck, but it looks some there's something on the wall.";

                        SFX.clip = doorStuck;
                        SFX.Play();

                        if (!paperSpawn)
                        {
                            paperClone = Instantiate(paper, new Vector3(74.2f, 1.34f, 412.38f), Quaternion.Euler(90, 0, 0));
                            paperSpawn = true;
                        }
                        interact = true;
                    }
                }
            }
            else

            if (hit.collider.gameObject.tag == "key")
            {
                interactHint.textOn = true;
                if (!interact)
                {
                    if (Input.GetButton("Interact"))
                    {
                        textHint.textOn = true;
                        //paper.transform.position = paper.transform.position + Camera.main.transform.forward * 5 * Time.deltaTime;
                        textHint.Hint.text = "There's a key and a note saying: \"Find me in the next building.\"";
                        Destroy(paperClone);

                        hasKey = true;

                        interact = true;

                        StartCoroutine(startRain());
                        interact = true;
                    }
                }
            }
            else
           if (hit.collider.gameObject.tag == "hospitalDoor")
            {
                interactHint.textOn = true;
                if (!interact)
                {
                    if (Input.GetButton("Interact"))
                    {
                        if (!hasKey)
                        {
                            textHint.textOn = true;
                            textHint.Hint.text = "Locked. A key might open this.";
                        }
                        else
                        {
                            SFX.clip = doorOpen;
                            SFX.Play();
                            playerScript.enabled = false;
                            GameObject.FindGameObjectWithTag("blackScreen").GetComponent<Image>().color = new Color(0, 0, 0, 255);
                            StartCoroutine(enterBuilding());
                        }
                    }
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
        if (start)
        {
            gameStart();

            start = false;
        }

        if (tutorial)
        {
            interact = true;
            tutorial = false;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.gameObject.tag == "wall")
        {
            boundaryHit = true;
            textHint.textOn = true;
            textHint.Hint.text = "Wandering away from my car is dangerous. Better head back.";
        }
        else if (!(hit.collider.gameObject.tag == "wall"))
        {
            if (boundaryHit)
            {
                timer += Time.deltaTime;
                if (timer > 3)
                {
                    textHint.clearText();
                    timer = 0;
                    boundaryHit = false;
                }
            }
        }
    }

    public static void gameStart()
    {
        playerScript.enabled = true;
        ambient.mute = false;
        playerCam.enabled = true;
        playerListen.enabled = true;

        textHint.textOn = true;
        textHint.Hint.text = "Press WASD to walk around. Mouse to look around.";

        tutorial = true;
    }

    private IEnumerator startRain()
    {
        yield return new WaitForSeconds(3);
        ambient.clip = raining;
        ambient.Play();
        rain.SetActive(true);
        textHint.textOn = true;
        textHint.Hint.text = "Started raining, better head into the other building for shelter.";
        StartCoroutine(sprintTutorial());
    }

    private IEnumerator sprintTutorial()
    {
        yield return new WaitForSeconds(5);
        textHint.textOn = true;
        textHint.Hint.text = "Press SHIFT to sprint.";
        interact = true;
    }

    private IEnumerator enterBuilding()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Scene1");
    }
}