using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [Range (-1, 5000)] [SerializeField] public int hp;
    [Range (5f, 20f)] [SerializeField] public float speed = 10f;
    public float velocity;
    public bool jump;

    public abstract void Move();
}
