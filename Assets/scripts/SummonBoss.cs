using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummonBoss : MonoBehaviour
{
    public Text uiText;
    private string informationText = "Press E to fix coffin";
    private bool canSummonBoss = false;
    private bool bossSummoned = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("SUMMON BOSS");
            bossSummoned = true;
            uiText.text = "";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(bossSummoned == false)
        {
            canSummonBoss = true;
            uiText.text = informationText;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(bossSummoned == false)
        {
            canSummonBoss = false;
            uiText.text = "";
        }
    }
}
