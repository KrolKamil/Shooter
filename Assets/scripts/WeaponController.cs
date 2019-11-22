using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeaponController : MonoBehaviour
{
    public GameObject basicBullet;
    public GameObject explodingBullet;

    public Image uiSkill1;
    public Image uiSkill2;

    public Text uiTextSkill1;
    public Text uiTextSkill2;

    private Weapon PlayerWeapon;
    private float defaultDelayBetweenShoots;

    private float timer = 15.0f;

    public float loadTimeSkill1 = 10.0f;
    public float loadTimeSkill2 = 15.0f;

    private float skillFiredAt1 = 0.0f;
    private float skillFiredAt2 = 0.0f;

    public float timeUsingSkill1 = 3.0f;
    public float timeUsingSkill2 = 3.0f;

    private bool activeSkill1 = false;
    private bool activeSkill2 = false;

    //public GameObject 
    // Start is called before the first frame update
    void Start()
    {
        PlayerWeapon = gameObject.GetComponent<Weapon>();
        defaultDelayBetweenShoots = PlayerWeapon.delayBetweenShoots;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //float timeBetweenShoot = timer - shootedAt;

        float loadTime1 = loadTimeSkill1 - (timer - skillFiredAt1);
        if (loadTime1 < 0)
        {
            uiTextSkill1.text = "";
        }
        else
        {
            uiTextSkill1.text = loadTime1.ToString();
        }

        float loadTime2 = loadTimeSkill2 - (timer - skillFiredAt2);
        if (loadTime2 < 0)
        {
            uiTextSkill2.text = "";
        }
        else
        {
            uiTextSkill2.text = loadTime2.ToString();
        }

        if (activeSkill1 == true)
        {
            if((timer - skillFiredAt1) >= timeUsingSkill1)
            {
                disableSkill1();
            }
        }

        if(activeSkill2 == true)
        {
            if ((timer - skillFiredAt2) >= timeUsingSkill2)
            {
                disableSkill2();
            }
        }
        

        if (Input.GetKeyDown("1"))
        {
            if((timer - skillFiredAt1) >= loadTimeSkill1)
            {
                skillFiredAt1 = timer;
                runSkill1();
            }
        }

        if (Input.GetKeyDown("2"))
        {
            if ((timer - skillFiredAt2) >= loadTimeSkill2)
            {
                skillFiredAt2 = timer;
                runSkill2();
            }
        }
    }

    private void runSkill1()
    {
        activeSkill1 = true;
        PlayerWeapon.bulletPrefab = explodingBullet;
    }

    private void runSkill2()
    {
        activeSkill2 = true;
        PlayerWeapon.delayBetweenShoots = 0.1f;
    }

    private void disableSkill1()
    {
        activeSkill1 = false;
        PlayerWeapon.bulletPrefab = basicBullet;
    }

    private void disableSkill2()
    {
        activeSkill2 = false;
        PlayerWeapon.delayBetweenShoots = defaultDelayBetweenShoots;
    }
}
