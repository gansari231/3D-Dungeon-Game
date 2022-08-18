using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingState : BaseState
{
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        enemyView.activeState = EnemyState.Patrolling;
    }

    protected override void Start()
    {
        base.Start();
        ChangeWalkPoint();
    }

    private void Update()
    {
        if (enemyModel.inChaseRange && !enemyModel.inAttackRange) enemyView.currentState.ChangeState(enemyView.CState);
        else if (enemyModel.inChaseRange && enemyModel.inAttackRange) enemyView.currentState.ChangeState(enemyView.AState);

        Patroling();
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }

    private void Patroling()
    {
        if (!enemyModel.walkPointSet)
        {
            SearchWalkPoint();
        }
        if (enemyModel.walkPointSet)
        {
            enemyView.navAgent.SetDestination(enemyModel.walkPoint);
        }
        Vector3 distanceToWalkPoint = enemyView.transform.position - enemyModel.walkPoint;
        if (distanceToWalkPoint.magnitude < 1f)
        {
            enemyModel.walkPointSet = false;
        }
    }

    public async void ChangeWalkPoint()
    {
        while (true)
        {
            await new WaitForSeconds(5.0f);
            enemyModel.walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-enemyModel.walkPointRange, enemyModel.walkPointRange);
        float randomX = Random.Range(-enemyModel.walkPointRange, enemyModel.walkPointRange);

        enemyModel.walkPoint = new Vector3(enemyView.transform.position.x + randomX, enemyView.transform.position.y, enemyView.transform.position.z + randomZ);

        if (Physics.Raycast(enemyModel.walkPoint, -enemyView.transform.up, 20f, enemyView.groundLayerMask))
        {
            enemyModel.walkPointSet = true;
        }
    }
}
