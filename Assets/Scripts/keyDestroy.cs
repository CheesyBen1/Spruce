using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyDestroy : MonoBehaviour
{
    private Camera playerCam;

    // Start is called before the first frame update
    private void Start()
    {
        playerCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void moveToCamera()
    {
        transform.position = transform.position + Camera.main.transform.forward * 5 * Time.deltaTime;
    }

    public void destoryKey()
    {
        Destroy(gameObject);
    }
}