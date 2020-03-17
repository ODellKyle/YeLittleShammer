using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D plyrRgdBdy;
    private BoxCollider2D plyrBoxCollider;
    float horizontalMovement;
    bool jump = false;
    bool onGround = true;


    private void Awake()
    {
        plyrRgdBdy = GetComponent<Rigidbody2D>();
        plyrBoxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal") * 20f;
        if (Input.GetButtonDown("Jump"))
          jump = true;

        onGround = plyrBoxCollider.IsTouchingLayers();
        if (plyrBoxCollider.IsTouchingLayers())
            Debug.Log("Touching!");
    }

    void FixedUpdate()
    {
        Move(horizontalMovement * Time.fixedDeltaTime, jump);
        jump = false;
    }

    public void Move(float mvmnt, bool jump) 
    {
        Vector3 moveVelocity = new Vector2(mvmnt * 10f, plyrRgdBdy.velocity.y);
        plyrRgdBdy.velocity = moveVelocity;

        if (jump && onGround) 
        {
            onGround = false;
            plyrRgdBdy.AddForce(new Vector2(0f, 400f));
        }
    }
}
