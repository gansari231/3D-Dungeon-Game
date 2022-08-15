using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingState : BaseState
{
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        enemyView.activeState = EnemyState.Chasing;
    }

    private void Update()
    {
        if (!enemyModel.inChaseRange && !enemyModel.inAttackRange) enemyView.currentState.ChangeState(enemyView.PState);
        else if (enemyModel.inChaseRange && enemyModel.inAttackRange) enemyView.currentState.ChangeState(enemyView.AState);

        ChasePlayer();
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }

    private void ChasePlayer()
    {
        if (!enemyView.playerTransform)
        {
            enemyView.currentState.ChangeState(enemyView.PState);
            return;
        }
        enemyView.navAgent.SetDestination(enemyView.playerTransform.position);
    }
}
