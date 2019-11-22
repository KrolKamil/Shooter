using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummonBoss : MonoBehaviour
{
    public Text uiText;
    public GameObject Boss;
    private string informationText = "Press E to fix coffin";
    private bool canSummonBoss = false;
    private bool bossSummoned = false;
    private bool playerWantSummonBoss = false;

    private float timer;
    private float startedSummoningAt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(playerWantSummonBoss == true)
        {
            float countDown = 3.0f - (timer - startedSummoningAt);

            uiText.text = countDown.ToString();

            if(countDown < 0)
            {
                playerWantSummonBoss = false;
                uiText.text = "";
                Transform t = gameObject.GetComponent<Transform>();
                Instantiate(Boss, t.position, t.rotation);
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        { 
            if(bossSummoned == false)
            {
                bossSummoned = true;
                uiText.text = "";
                playerWantSummonBoss = true;
                startedSummoningAt = timer;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController pc = collision.GetComponent<PlayerController>();
        if (pc != null)
        {
            if (bossSummoned == false)
            {
                canSummonBoss = true;
                uiText.text = informationText;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController pc = collision.GetComponent<PlayerController>();
        if (pc != null)
        {
            if (bossSummoned == false)
            {
                canSummonBoss = false;
                uiText.text = "";
            }
        }
    }
}
