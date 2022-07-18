using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    private float characterVelocity = 2f;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;
    // Start is called before the first frame update
    void Start()
    {
        movementDirection = new Vector2(Random.Range(-6.0f, 20.0f), Random.Range(27.0f, 44.0f)).normalized;
        movementPerSecond = movementDirection * characterVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime),
        transform.position.y + (movementPerSecond.y * Time.deltaTime));
    }
}
