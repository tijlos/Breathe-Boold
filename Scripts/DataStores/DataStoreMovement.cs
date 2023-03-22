using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using System;
using Random = System.Random;

public class DataStoreMovement
{
    public float MoveSpeed = 2f;
    public float MoveSpeedShark = 0.8f;
    public float MoveSpeedVis = 1f;
    public float Health;
    public int Death = -1;
    public Vector2 MoveDirection { get; set; }

    public bool HitOxygen = false;

    public SpriteRenderer spriteRenderer;

    public static DataStoreMovement Instance
    {
        get
        {
            if (instance == null) instance = new DataStoreMovement();
            return instance;
        }
    }
    private static DataStoreMovement instance;
    private DataStoreMovement() { }
}
