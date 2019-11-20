using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    public Text uiTextHp;
    private string phText = "❤️❤️❤️";
    private int playerHp = 3;
    private float timer = 0.0f;
    private float gotHitAt = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        uiTextHp.text = playerHp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    public void TakeDamage()
    {
        float timeBetweenHits = timer - gotHitAt;
        if ((timeBetweenHits >= 3) || gotHitAt == 0.0f)
        {
            gotHitAt = timer;
            playerHp--;
            uiTextHp.text = playerHp.ToString();
            if (playerHp <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
