using System.Collections;
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
    public GameObject block;
    public GameObject fakeWall;
    public GameObject expandedFloor;
    public GameObject realWall;
    public GameObject key;
    public GameObject npcPlatform;
    public AudioClip failedSound;
    private bool failed;
    // Start is called before the first frame update
    void Start()
    {
        failed = false;
        greenLight1.SetActive(false);
        greenLight2.SetActive(false);
        greenLight3.SetActive(false);
        key.SetActive(false);
        pressurePlate1.SetSteppedOn(false);
        pressurePlate2.SetSteppedOn(false);
        pressurePlate3.SetSteppedOn(false);
        bossSpawner.SetActive(false);
        NPC.SetActive(false);
        npcPlatform.SetActive(false);
        block.SetActive(false);
        fakeWall.SetActive(true);
        realWall.SetActive(false);
        expandedFloor.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (pressurePlate1.GetSteppedOn() && !pressurePlate2.GetSteppedOn()
            && !pressurePlate3.GetSteppedOn())
        {
            failed = true;
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
        {
            ResetPuzzle();
        }
    }

    void Activate1()
    {
        greenLight1.SetActive(true);
        //Debug.Log("Activate1!");
    }

    void Activate2() 
    {
        greenLight2.SetActive(true);
        //Debug.Log("Activate2!");
    }

    void Unlock() 
    {
        greenLight3.SetActive(true);
        
        if (!Player.Instance.inventory[1])
        {
            key.SetActive(BossEnemy.bossDefeated);
            
            bossSpawner.SetActive(true);
            block.SetActive(BossEnemy.bossActivated);

        }
        fakeWall.SetActive(false);
        realWall.SetActive(true);
        expandedFloor.SetActive(true);
        door.SetActive(Lock.unlocked);
        NPC.SetActive(Lock.unlocked);
        npcPlatform.SetActive(Lock.unlocked);

        //Debug.Log("Unlocked!");
    }

    private void ResetPuzzle()
    {
        if (failed) 
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = failedSound;
            audio.Play();
            failed = false;
        }
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
        npcPlatform.SetActive(false);
        fakeWall.SetActive(true);
        realWall.SetActive(false);
        expandedFloor.SetActive(false);
        BossEnemy.bossActivated = false;
        BossEnemy.bossDefeated = false;
        Lock.unlocked = false;
    }
}
