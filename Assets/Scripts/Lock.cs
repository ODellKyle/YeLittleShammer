using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public static bool unlocked = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if(player != null) 
        {
            if (Player.Instance.inventory[1])
            {
                unlocked = true;
                CreditsManager.gameFinished = true;
            }
        }
    }
}
