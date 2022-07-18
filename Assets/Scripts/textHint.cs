using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textHint : MonoBehaviour
{
    public static bool textOn = false;
    public static string message;
    private float timer = 0.0f;

    public static Text Hint;

    // Start is called before the first frame update
    private void Start()
    {
        Hint = GetComponent<Text>();
        timer = 0.0f;
        textOn = false;
        Hint.text = "";
    }

    // Update is called once per frame
    private void Update()
    {
        Hint.enabled = textOn;
    }

    public static void clearText()
    {
        textOn = false;
        Hint.text = "";
    }
}