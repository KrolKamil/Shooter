﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private GameController gc;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        gc.gainPoint();
    }
}
