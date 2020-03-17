using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
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

    float horizontalMovement;
    public bool jump = false;
    public BoxCollider2D plyrBoxCollider;
    public Rigidbody2D plyrRgdBdy;
    public PlayerMovement mvmt;


    // Start is called before the first frame update
    void Start()
    {
        plyrBoxCollider = GetComponent<BoxCollider2D>();
        plyrRgdBdy = GetComponent<Rigidbody2D>();
        mvmt = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal") * 20f;
        if (Input.GetButtonDown("Jump"))
            jump = true;
    }

    void FixedUpdate()
    {
        mvmt.Move(horizontalMovement * Time.fixedDeltaTime, jump);
        jump = false;
    }

    public BoxCollider2D GetPlyrBoxCollider()
    {
        return this.plyrBoxCollider;
    }
}
