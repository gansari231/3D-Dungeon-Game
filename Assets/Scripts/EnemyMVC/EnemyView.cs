using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyView : MonoBehaviour
{
    Animator enemyAnimator;
    public EnemyController _enemyController;

    public PatrollingState PState;
    public AttackingState AState;
    public ChasingState CState;

    [SerializeField] private EnemyState initialState;
    [HideInInspector] public EnemyState activeState;
    [HideInInspector] public BaseState currentState;

    [HideInInspector]
    public Transform playerTransform;
    public NavMeshAgent navAgent;
    public LayerMask playerLayerMask;
    public LayerMask groundLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        navAgent = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();
        InitializeState();     
    }

    // Update is called once per frame
    void Update()
    {
        _enemyController.RangeCheck();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerService.Instance._playerController._playerView.TakeDamage(_enemyController._enemyModel.damage);
        }
    }
    public void SetEnemyController(EnemyController enemyController)
    {
        this._enemyController = enemyController;
    }

    public void AttackPlayer()
    {
        enemyAnimator.SetTrigger("Attack");
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Enemy Taking Damage: " + damage);
        _enemyController.UpdateHealth(damage);
    }

    private void InitializeState()
    {
        switch (initialState)
        {
            case EnemyState.Attacking:
                {
                    currentState = AState;
                    break;
                }
            case EnemyState.Chasing:
                {
                    currentState = CState;
                    break;
                }
            case EnemyState.Patrolling:
                {
                    currentState = PState;
                    break;
                }
            default:
                {
                    currentState = null;
                    break;
                }
        }
        currentState.OnStateEnter();
    }

    /*public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemyController.enemyModel.attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, enemyController.enemyModel.chaseRange);
    }*/
}
