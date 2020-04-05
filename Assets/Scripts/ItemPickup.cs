using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public GameObject item;
    public int itemNumber;

    public class Items 
    {
        static bool weapon = false;
        static bool key = false;
        public static List<bool> items = new List<bool>() { weapon, key };
    }
    // Start is called before the first frame update
    void Start()
    {
        if (Player.Instance.inventory[itemNumber])
            item.SetActive(false);
        else
            item.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player.Instance.inventory[itemNumber] = true;
            Player.Instance.ActivateItem(itemNumber);
            item.SetActive(false);
        }
    }
}
