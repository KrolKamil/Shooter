using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public GameObject enemy;
    private Transform transformToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        enemy.transform.position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createEnemy()
    {
        Instantiate(enemy);
    }
}
