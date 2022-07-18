using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gas1GUI : MonoBehaviour
{
    public Texture gas1tex;
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
        if (gasGUI.gas == 2)
        {
            img.texture = gas1tex;
            img.enabled = true;
        }
    }
}
