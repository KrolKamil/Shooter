using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{

    private Transform firePoint;
    public GameObject bulletPrefab;
    private float timer = 0.0f;
    private float shootedAt = 0.0f;
    float distance = 100000f;
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.GetComponent < Transform > ();
        firePoint = gameObject.transform.Find("FirePoint");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        float timeBetweenShoot = timer - shootedAt;
        distance = Vector2.Distance(playerTransform.position, transform.position);
        if(distance <= 10)
        {
            if (timeBetweenShoot >= 1)
            {
                shootedAt = timer;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
