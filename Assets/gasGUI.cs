using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gasGUI : MonoBehaviour
{
    public static int gas = 0;
    public Texture gas1tex;
    private RawImage img;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<RawImage>();
        img.enabled = false;
        gas = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gas == 1)
        {
            img.texture = gas1tex;
            img.enabled = true;
        }
    }
}
