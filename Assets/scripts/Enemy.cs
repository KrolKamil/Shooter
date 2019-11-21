using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

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
}
