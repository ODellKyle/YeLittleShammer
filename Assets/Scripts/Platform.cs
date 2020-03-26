using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Collider2D collider;
    public PlatformEffector2D platformEffector;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        platformEffector = GetComponent<PlatformEffector2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        collider.enabled = !(Input.GetAxisRaw("Vertical") < 0);
        platformEffector.enabled = !(Input.GetAxisRaw("Vertical") < 0);
    }
}
