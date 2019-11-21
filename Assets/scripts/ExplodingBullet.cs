using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingBullet : MonoBehaviour
{
    public float speed = 20f;

    private Rigidbody2D rb;
    public GameObject basicBullet;
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
        if ((collision.gameObject.tag != "Spawn") && (collision.gameObject.tag != "Bullet"))
        {
            spawnSingeButtons();
            Destroy(gameObject);
        }
    }

    private void spawnSingeButtons()
    {
        for(int i=0; i<=360; i += 60)
        {

            basicBullet.transform.position = gameObject.transform.position;
            basicBullet.transform.rotation = new Quaternion(0, i, 0, 0);
            Instantiate(basicBullet);
        }
    }
}
