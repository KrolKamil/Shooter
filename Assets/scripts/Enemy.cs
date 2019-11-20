using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public int health = 100;
    public Transform playerTransform;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = playerTransform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }
    void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    public void TakeDamage (int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHp playerFromConllision = collision.gameObject.GetComponent<PlayerHp>();
        if (playerFromConllision != null)
        {
            playerFromConllision.TakeDamage();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHp playerFromConllision = collision.GetComponent<PlayerHp>();
        if (playerFromConllision != null)
        {
            playerFromConllision.TakeDamage();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
