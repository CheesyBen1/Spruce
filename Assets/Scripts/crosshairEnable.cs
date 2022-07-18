using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class crosshairEnable : MonoBehaviour
{
    private static RawImage crosshair;

    // Start is called before the first frame update
    private void Start()
    {
        crosshair = GetComponent<RawImage>();
        crosshair.enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public static void enable()
    {
        crosshair.enabled = true;
    }
}