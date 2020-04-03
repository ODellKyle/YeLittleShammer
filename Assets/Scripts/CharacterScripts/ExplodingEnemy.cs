using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingEnemy : Enemy
{
    public AudioClip explosion;
    private bool exploded = false;
    // Start is called before the first frame update
    void Start()
    {
        hp = Random.Range(5, 15);
        speed = Random.Range(2f, 4f);
        damage = 30;
        mvmt = GetComponent<PlayerMovement>();
        jump = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Player player = collision.collider.GetComponent<Player>();

        if (player != null)
        {
            Explode(player);
        }
    }

    private void Explode(Player player) 
    {
        if (!exploded)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = explosion;
            audio.Play();
            player.TakeDamage(damage);
            //perform explosion animation
            this.TakeDamage(hp);
            exploded = true;
        }
    }
}
