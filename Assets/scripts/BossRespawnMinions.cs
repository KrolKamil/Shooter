using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRespawnMinions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        HitPoints hp = gameObject.GetComponent<HitPoints>();
        SpawnEnemy sp = gameObject.GetComponent<SpawnEnemy>();
        sp.createEnemy();
        sp.createEnemy();
        sp.createEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
