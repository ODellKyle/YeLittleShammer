using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    public GameObject gunImage;
    public GameObject keyImage;
    private List<GameObject> items;

    void Start()
    {
        items = new List<GameObject>() { gunImage, keyImage };
    }

    // Update is called once per frame
    void Update()
    {
        HasItems();
    }

    void HasItems() 
    {
        //for(int i = 0; i < items.Count; i++) 
        //{
            items[0].SetActive(Player.Instance.inventory[0]);
        items[1].SetActive(Player.Instance.inventory[1]);
        //}
    }
}
