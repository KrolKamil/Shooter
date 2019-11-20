using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedModerator;

    private Rigidbody2D rgb2d;
    private Vector2 currentDirrection;

    // Start is called before the first frame update
    void Start()
    {
        this.rgb2d = GetComponent<Rigidbody2D>();
        this.currentDirrection = Vector2.zero;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        this.currentDirrection = new Vector2(moveHorizontal, moveVertical);
        //transform.Translate(this.currentDirrection);
        this.rgb2d.velocity = this.currentDirrection * speedModerator;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        this.currentDirrection = Vector3.zero;
        this.rgb2d.velocity = Vector3.zero;
    }
}
