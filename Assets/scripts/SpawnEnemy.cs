using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public GameObject enemy;
    public GameObject shooter;
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

    public void createEnemy(Transform hook)
    {
        Instantiate(enemy, hook.position, hook.rotation);
    }

    public void createShooter(Transform hook)
    {
        Instantiate(shooter, hook.position, hook.rotation);
    }
}
