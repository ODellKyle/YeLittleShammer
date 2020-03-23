using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private static Player instance;
    public static Player Instance { get { return instance; } }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }

    public PlayerMovement mvmt;


    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
        jump = true;
        collider = GetComponent<BoxCollider2D>();
        mvmt = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = Input.GetAxisRaw("Horizontal") * speed;
        if (Input.GetButtonDown("Jump"))
            jump = true;
    }

    void FixedUpdate()
    {
        //Move();
    }

    private void LateUpdate()
    {
        Move();
    }


    public void TakeDamage(int damage) 
    {
        hp -= damage;
    }

    public override void Move()
    {
        mvmt.Move(velocity * Time.fixedDeltaTime, jump);
        jump = false;
    }
}
