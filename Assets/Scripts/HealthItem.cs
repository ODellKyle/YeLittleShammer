using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public GameObject item;
    public AudioClip healingSound;
    private bool used = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = healingSound;
        if (player != null && !used)
        {
            audio.Play();
            player.hp = 150;
            used = true;
            StartCoroutine(Healing());
        }
    }

    IEnumerator Healing() 
    {
        yield return new WaitForSeconds(.5f);
        item.SetActive(false);
    }
}
