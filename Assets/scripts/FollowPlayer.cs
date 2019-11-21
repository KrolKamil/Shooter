using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform playerTransform;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = playerTransform.position - transform.position;
        float distane = Mathf.Sqrt((direction.x * direction.x) + (direction.y * direction.y));
        if (distane < 8)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;
        }
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
