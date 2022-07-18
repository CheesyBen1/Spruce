using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class candleGUI : MonoBehaviour
{
    public Texture candle1tex;
    private RawImage img;
    public static int candle = 0;

    // Start is called before the first frame update
    private void Start()
    {
        img = GetComponent<RawImage>();
        img.enabled = false;
        candle = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (candle == 1)
        {
            img.texture = candle1tex;
            img.enabled = true;
        }
    }
}