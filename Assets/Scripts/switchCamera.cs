using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class switchCamera : MonoBehaviour
{
    public static bool camEnable = false;

    private Camera cam;
    private AudioListener listen;

    // Start is called before the first frame update
    private void Start()
    {
        cam = GetComponent<Camera>();
        listen = GetComponent<AudioListener>();

        cam.enabled = camEnable;
        listen.enabled = camEnable;
    }

    // Update is called once per frame
    private void Update()
    {
        if (camEnable)
        {
            cam.enabled = true;
            listen.enabled = true;
        }
    }
}