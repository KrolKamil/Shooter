using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHp playerFromConllision = collision.GetComponent<PlayerHp>();
        if (playerFromConllision != null)
        {
            playerFromConllision.TakeDamage();
        }
        if ((collision.gameObject.tag != "Spawn") && (collision.gameObject.tag != "Enemy") && (collision.gameObject.tag != "Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
