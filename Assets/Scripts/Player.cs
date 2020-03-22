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
    public Vector3 prevLocation;
    public Vector3 nextLocation;


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
        speed = Input.GetAxisRaw("Horizontal") * 20f;
        if (Input.GetButtonDown("Jump"))
            jump = true;
    }

    void FixedUpdate()
    {
        Move();
    }


    public void TakeDamage(int damage) 
    {
        hp -= damage;
    }

    public override void Move()
    {
        mvmt.Move(speed * Time.fixedDeltaTime, jump);
        jump = false;
    }
}
