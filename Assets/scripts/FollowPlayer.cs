using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform playerTransform;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float distance = 1000000.0f;

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
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle -= 90;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
        //distance = Mathf.Sqrt((direction.x * direction.x) + (direction.y * direction.y));
        //Debug.Log(distance);
        distance = Vector2.Distance(playerTransform.position, transform.position);
    }

    private void FixedUpdate()
    {
        if (distance < 10)
        {
            moveCharacter(movement);
        }
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
