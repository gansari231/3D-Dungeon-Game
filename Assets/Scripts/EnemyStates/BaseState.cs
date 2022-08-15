using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyView))]

public class BaseState : MonoBehaviour
{
    protected EnemyView enemyView;
    protected EnemyModel enemyModel;

    protected virtual void Awake()
    {
        enemyView = GetComponent<EnemyView>();
    }

    protected virtual void Start()
    {
        enemyModel = enemyView._enemyController._enemyModel;
    }
    public virtual void OnStateEnter()
    {
        this.enabled = true;
    }

    public virtual void OnStateExit()
    {
        this.enabled = false;
    }

    public void ChangeState(BaseState newState)
    {
        if (enemyView.currentState != null)
        {
            enemyView.currentState.OnStateExit();
        }

        enemyView.currentState = newState;
        enemyView.currentState.OnStateEnter();
    }
}
