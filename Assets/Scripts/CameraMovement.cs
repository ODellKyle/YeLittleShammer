﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float panVer = 10f;
    private float panHor = 17.8f;
    private float depth = -10f;
    public static Vector3 prevLocation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Vector3 screenPan = transform.position;

        if (Player.Instance.transform.position.y >= transform.position.y + (panVer / 2.0f))
            transform.position = new Vector3(transform.position.x, transform.position.y + panVer, depth);

        if (Player.Instance.transform.position.y <= transform.position.y - (panVer / 2.0f))
            transform.position = new Vector3(transform.position.x, transform.position.y - panVer, depth);

        if (Player.Instance.transform.position.x >= transform.position.x + (panHor / 2.0f))
            transform.position = new Vector3(transform.position.x + panHor, transform.position.y, depth);

        if (Player.Instance.transform.position.x <= transform.position.x - (panHor / 2.0f))
            transform.position = new Vector3(transform.position.x - panHor, transform.position.y, depth);

        //transform.position = screenPan;

    }

    public static void SetCamera() 
    {
        
    }
}
