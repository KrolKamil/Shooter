using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRespawnMinions : MonoBehaviour
{
    private HitPoints hp;
    private SpawnEnemy sp;
    private Transform hook;

    private float timer = 10.0f;
    private float lastTimeSpawned;
    // Start is called before the first frame update
    public float delayBetweendSpawn = 10.0f;

    private float hpStage1 = 2000;
    private float hpStage2 = 1000;
    private float startHp;
    void Start()

    {
        hp = gameObject.GetComponent<HitPoints>();
        sp = gameObject.GetComponent<SpawnEnemy>();
        hook = gameObject.GetComponent<Transform>();
        startHp = hp.health;
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(startHp != hp.health)
        {
            if((timer - lastTimeSpawned) > delayBetweendSpawn)
            {
                lastTimeSpawned = timer;
                createElnemies();
                createShooter();
            }
        }

    }

    private void createElnemies()
    {
        sp.createEnemy(hook);
        sp.createEnemy(hook);
    }

    private void createShooter()
    {
        sp.createShooter(hook);
        sp.createShooter(hook);
    }
}
