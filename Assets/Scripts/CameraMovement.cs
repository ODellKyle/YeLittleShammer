﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject plr;
    private float panVer = 10f;
    private float panHor = 17.8f;
    private float depth = -10f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 screenPan = transform.position;

        if (plr.transform.position.y >= transform.position.y + (panVer / 2.0f))
            transform.position = new Vector3(0, transform.position.y + panVer, depth);

        if (plr.transform.position.y <= transform.position.y - (panVer / 2.0f))
            transform.position = new Vector3(0, transform.position.y - panVer, depth);

        if (plr.transform.position.x >= transform.position.x + (panHor / 2.0f))
            transform.position = new Vector3(transform.position.x + panHor, 0, depth);

        if (plr.transform.position.x <= transform.position.x - (panHor / 2.0f))
            transform.position = new Vector3(transform.position.x - panHor, 0, depth);

        //transform.position = screenPan;

    }
}