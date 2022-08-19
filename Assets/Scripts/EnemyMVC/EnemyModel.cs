using UnityEngine;

public class EnemyModel
{
    public int health { get; set; }
    public int damage { get; }
    public float chaseRange { get; }
    public float attackRange { get; }
    public bool inChaseRange { get; set; }
    public bool inAttackRange { get; set; }
    public bool isAlive { get; set; }

    // For Patrolling of Enemy
    public Vector3 walkPoint { get; set; }
    public float walkPointRange { get; set; }
    public bool walkPointSet { get; set; }

    // For Attacking of Enemy
    public float timeBetweenAttacks { get; set; }
    public bool isAttack { get; set; }

    public EnemyModel()
    {
        isAlive = true;
        health = 20;
        damage = 5;
        chaseRange = 10.0f;
        attackRange = 3.0f;
        walkPointRange = 50.0f;
        timeBetweenAttacks = 7.0f;
    }
}
