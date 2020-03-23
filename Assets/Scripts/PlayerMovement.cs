using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool onGround = true;
    public float jumpForce = 250f;
    bool doubleJump = false;
    bool facingRight = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        onGround = rb.IsTouchingLayers();
        //onGround = Player.Instance.plyrBoxCollider.IsTouchingLayers();
    }

    public void Move(float mvmnt, bool jump) 
    {
        if (mvmnt < 0 && facingRight)
            Flip();

        if (mvmnt > 0 && !facingRight)
            Flip();

        Vector3 moveVelocity = new Vector2(mvmnt * 20f, rb.velocity.y);
        rb.velocity = moveVelocity;

        if (jump && onGround) 
        {
            onGround = false;
            doubleJump = true;
            rb.AddForce(new Vector2(0f, jumpForce));
        }
        else if(jump && doubleJump) 
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            doubleJump = false;
        }
    }

    public void Flip() 
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0);
    }

}
