using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    private float timer = 0.0f;
    private float shootedAt = 0.0f;
    private bool shoot = false;
    public float delayBetweenShoots = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            shoot = true;
        }

        timer += Time.deltaTime;
        float timeBetweenShoot = timer - shootedAt;
        if (timeBetweenShoot >= delayBetweenShoots)
        {
            shootedAt = timer;
            if (shoot == true)
            {
                Shoot();
            }
        }

        if (Input.GetButtonUp("Fire1"))
        {
            shoot = false;
        }
    }
    
    void Shoot ()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
