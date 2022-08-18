using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel
{
    public float rotationSpeed { get; set; } 
    public float speed { get; set; }
    public int health { get; set; }
    public int damage { get; }
    public bool isDead { get; set; }
    public PlayerModel()
    {
        rotationSpeed = 200.0f;
        speed = 4.0f;
        health = 10;
        damage = 5;
    }
    
}
