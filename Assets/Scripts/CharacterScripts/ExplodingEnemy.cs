﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        hp = Random.Range(50, 100);
        speed = Random.Range(10f, 15f);
        damage = 30;
        mvmt = GetComponent<PlayerMovement>();
        collider = GetComponent<BoxCollider2D>();
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
        player.TakeDamage(damage);
        //perform explosion animation
        this.TakeDamage(hp);
    }
}