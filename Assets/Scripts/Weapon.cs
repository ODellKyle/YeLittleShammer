﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectileprefab;
    public float coolDown = .5f;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if(Time.time - timer > coolDown)
                Shoot();
        }
    }

    void Shoot() 
    {
        Instantiate(projectileprefab, firePoint.position, firePoint.rotation);
    }
}
