using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class matchGUI : MonoBehaviour
{
    public static int matches = 0;
    public Texture matchestex;
    private RawImage img;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<RawImage>();
        img.enabled = false;
        matches = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (matches == 1)
        {
            img.texture = matchestex;
            img.enabled = true;
        }
    }
}
