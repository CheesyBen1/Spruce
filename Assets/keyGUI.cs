using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyGUI : MonoBehaviour
{
    public static int key = 0;
    public Texture key1tex;
    private RawImage img;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<RawImage>();
        img.enabled = false;
        key = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (key == 1)
        {
            img.texture = key1tex;
            img.enabled = true;
        }

    }
}
