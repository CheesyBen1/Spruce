using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public float enemyXPos;
    public float enemyZPos;
    private int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while (enemyCount < 1)
        {
            enemyXPos = Random.Range(-6, 20);
            enemyZPos = Random.Range(27, 44);
            Instantiate(enemy, new Vector3(enemyXPos, 0.5f, enemyZPos), Quaternion.identity);
            enemyCount++;
        }
        
        
    }
}
