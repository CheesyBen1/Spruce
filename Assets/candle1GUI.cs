using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class candle1GUI : MonoBehaviour
{
    public Texture candle1tex;
    private RawImage img;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<RawImage>();
        img.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (candleGUI.candle == 2)
        {
            img.texture = candle1tex;
            img.enabled = true;
        }
    }
}
