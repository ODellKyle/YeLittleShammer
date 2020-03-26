﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [Range (100, 1000)] [SerializeField] public int hp;
    [Range (5f, 20f)] [SerializeField] public float speed = 10f;
    public float velocity;
    public bool jump;
    public Collider2D collider;

    public abstract void Move();
}