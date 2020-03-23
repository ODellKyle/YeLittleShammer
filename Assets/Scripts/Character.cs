using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public int hp;
    public float speed;
    public float velocity;
    public bool jump;
    public Collider2D collider;

    public abstract void Move();
}
