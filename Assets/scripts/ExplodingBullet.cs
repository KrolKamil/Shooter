using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingBullet : MonoBehaviour
{
    private Transform firePoint1;
    private Transform firePoint2;
    public int damage = 5;

    public float speed = 6f;

    private Rigidbody2D rb;
    public GameObject basicBullet;
    // Start is called before the first frame update

    private float timer = 0.0f;
    private float shootedAt = 0.0f;

    void Start()
    {
        firePoint1 = gameObject.transform.Find("FirePoint1");
        firePoint2 = gameObject.transform.Find("FirePoint2");

        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        float timeBetweenShoot = timer - shootedAt;
        if (timeBetweenShoot >= 0.1)
        {
            shootedAt = timer;
            spawnBaseBullets();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HitPoints hp = collision.GetComponent<HitPoints>();
        if (hp != null)
        {
            hp.TakeDamage(damage);
        }

        if ((collision.gameObject.tag != "Spawn") && (collision.gameObject.tag != "Bullet"))
        {
            spawnBaseBullets();
            Destroy(gameObject);
        }
    }

    private void spawnBaseBullets()
    {
        Instantiate(basicBullet, firePoint1.position, firePoint1.rotation);
        Instantiate(basicBullet, firePoint2.position, firePoint2.rotation);
    }
}
