using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //private Rigidbody2D plyrRgdBdy;
    bool onGround = true;


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
        Vector3 moveVelocity = new Vector2(mvmnt * 10f, Player.Instance.plyrRgdBdy.velocity.y);
        Player.Instance.plyrRgdBdy.velocity = moveVelocity;

        if (jump && onGround) 
        {
            onGround = false;
            Player.Instance.plyrRgdBdy.AddForce(new Vector2(0f, 400f));
        }
    }

}
