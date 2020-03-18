using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //private Rigidbody2D plyrRgdBdy;
    bool onGround = true;
    bool doubleJump = false;
    bool facingRight = true;

    private void Awake()
    {
        //plyrRgdBdy = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        onGround = Player.Instance.plyrBoxCollider.IsTouchingLayers();
    }

    void FixedUpdate()
    {
    }

    public void Move(float mvmnt, bool jump) 
    {
        if (mvmnt < 0 && facingRight)
            Flip();

        if (mvmnt > 0 && !facingRight)
            Flip();

        Vector3 moveVelocity = new Vector2(mvmnt * 10f, Player.Instance.plyrRgdBdy.velocity.y);
        Player.Instance.plyrRgdBdy.velocity = moveVelocity;

        if (jump && onGround) 
        {
            onGround = false;
            doubleJump = true;
            Player.Instance.plyrRgdBdy.AddForce(new Vector2(0f, 250f));
        }
        else if(jump && doubleJump) 
        {
            Player.Instance.plyrRgdBdy.AddForce(new Vector2(0f, 250f));
            doubleJump = false;
        }
    }

    public void Flip() 
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0);
    }

}
