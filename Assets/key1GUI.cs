using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class key1GUI : MonoBehaviour
{
    public Texture key1tex;
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
        if (keyGUI.key == 2)
        {
            img.texture = key1tex;
            img.enabled = true;
        }
    }
}
