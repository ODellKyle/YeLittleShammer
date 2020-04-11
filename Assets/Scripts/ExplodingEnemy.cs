using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingEnemy : Enemy
{
    public Animator animator;
    public AudioClip explosion;
    private bool exploded = false;
    // Start is called before the first frame update
    void Start()
    {
        mvmt = GetComponent<PlayerMovement>();
        jump = true;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("exploded", this.exploded);
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
            exploded = true;
            this.lockOnDistance = 0f;
            StartCoroutine(Exploding());
        }
    }

    IEnumerator Exploding() 
    {
        yield return new WaitForSeconds(1f);
        //perform explosion animation
        this.TakeDamage(hp);
    }
}
