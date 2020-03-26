﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool onGround = true;
    [Range(100f, 500f)] [SerializeField] public float jumpForce = 250f;
    [Range(0f, 500f)] [SerializeField] public float doubleJumpForce = 250f;
    bool doubleJump = false;
    bool facingRight = true;
    [Range(0f, 10f)] [SerializeField] public float velocityLimit = 7.5f;
    private float velocityCap;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        onGround = rb.IsTouchingLayers();
    }

    public void Move(float mvmnt, bool jump) 
    {
        if (mvmnt < 0 && facingRight)
            Flip();

        if (mvmnt > 0 && !facingRight)
            Flip();

        if (rb.velocity.y > velocityLimit)
            velocityCap = velocityLimit;
        else
            velocityCap = rb.velocity.y;

        Vector3 moveVelocity = new Vector2(mvmnt * 20f, velocityCap);
        rb.velocity = moveVelocity;

        if (jump && onGround) 
        {
            onGround = false;
            doubleJump = true;
            rb.AddForce(new Vector2(0f, jumpForce));
        }
        else if(jump && doubleJump) 
        {
            rb.AddForce(new Vector2(0f, doubleJumpForce));
            doubleJump = false;
        }
    }

    public void Flip() 
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0);
    }

}
