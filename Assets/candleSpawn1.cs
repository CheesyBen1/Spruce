using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class candleSpawn1 : MonoBehaviour
{
    public GameObject candle;
    private int candleCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while (candleCount < 1)
        {
            Instantiate(candle, new Vector3(24.16f, 0.05f, 48.82f), Quaternion.identity);
            candleCount++;
        }
    }
}
