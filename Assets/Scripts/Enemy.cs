using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 100;
    private float speed = 20f;
    public PlayerMovement mvmt;
    public bool jump = true;

    public void TakeDamage(int damage) 
    {
        hp -= damage;

        if (hp <= 0)
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        mvmt = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //jump = Player.Instance.jump;
    }

    void FixedUpdate()
    {
        jump = Player.Instance.jump;
        mvmt.Move(0f, jump);
        jump = false;
    }
}
