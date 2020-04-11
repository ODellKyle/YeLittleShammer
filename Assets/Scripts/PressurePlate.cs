using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public bool steppedOn = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            //Debug.Log("Stepping on!");
            steppedOn = true;
        }
    }

    public bool GetSteppedOn() 
    {
        return this.steppedOn;
    }

    public void SetSteppedOn(bool steppedOn) 
    {
        this.steppedOn = steppedOn;
    }
}
