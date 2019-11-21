using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 20;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HitPoints hp = collision.GetComponent<HitPoints>();
        if (hp != null)
        {
            hp.TakeDamage(damage);
        }
        if(collision.gameObject.tag != "Spawn")
        {
            Destroy(gameObject);
        }
    }
}
