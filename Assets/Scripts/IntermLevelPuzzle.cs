﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntermLevelPuzzle : MonoBehaviour
{
    public PressurePlate pressurePlate1;
    public PressurePlate pressurePlate2;
    public PressurePlate pressurePlate3;
    public GameObject greenLight1;
    public GameObject greenLight2;
    public GameObject greenLight3;
    public GameObject door;
    public GameObject bossSpawner;
    public GameObject NPC;

    public GameObject key;
    // Start is called before the first frame update
    void Start()
    {
        greenLight1.SetActive(false);
        greenLight2.SetActive(false);
        greenLight3.SetActive(false);
        key.SetActive(false);
        pressurePlate1.SetSteppedOn(false);
        pressurePlate2.SetSteppedOn(false);
        pressurePlate3.SetSteppedOn(false);
        bossSpawner.SetActive(false);
        NPC.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (pressurePlate1.GetSteppedOn() && !pressurePlate2.GetSteppedOn()
            && !pressurePlate3.GetSteppedOn())
        {
            Debug.Log("stepped on 1!");
            Activate1();
        }

        else if (pressurePlate1.GetSteppedOn() && pressurePlate2.GetSteppedOn()
            && !pressurePlate3.GetSteppedOn())
        {
            Activate2();
        }
        else if ((pressurePlate1.GetSteppedOn() && pressurePlate2.GetSteppedOn()
            && pressurePlate3.GetSteppedOn()) || Player.Instance.inventory[1])
        {
            Unlock();
        }
        else
            ResetPuzzle();
    }

    void Activate1()
    {
        greenLight1.SetActive(true);
        Debug.Log("Activate1!");
    }

    void Activate2() 
    {
        greenLight2.SetActive(true);
        Debug.Log("Activate2!");
    }

    void Unlock() 
    {
        greenLight3.SetActive(true);
        
        if (!Player.Instance.inventory[1])
        {
            key.SetActive(BossEnemy.bossDefeated);
            
            bossSpawner.SetActive(true);
        }

        door.SetActive(Lock.unlocked);
        NPC.SetActive(Lock.unlocked);

        Debug.Log("Unlocked!");
    }

    private void ResetPuzzle()
    {
        greenLight1.SetActive(false);
        greenLight2.SetActive(false);
        greenLight3.SetActive(false);
        key.SetActive(false);
        pressurePlate1.SetSteppedOn(false);
        pressurePlate2.SetSteppedOn(false);
        pressurePlate3.SetSteppedOn(false);
        bossSpawner.SetActive(false);
        door.SetActive(false);
        NPC.SetActive(false);
    }
}
