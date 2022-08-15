using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingState : BaseState
{
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        enemyView.activeState = EnemyState.Attacking;
    }

    private void Update()
    {
        if (!enemyModel.inChaseRange && !enemyModel.inAttackRange) enemyView.currentState.ChangeState(enemyView.PState);
        else if (enemyModel.inChaseRange && !enemyModel.inAttackRange) enemyView.currentState.ChangeState(enemyView.CState);

        AttackPlayer();
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }

    private async void AttackPlayer()
    {
        if (!enemyView.playerTransform)
        {
            enemyView.currentState.ChangeState(enemyView.PState);
            return;
        }
        enemyView.navAgent.SetDestination(enemyView.transform.position);

        if (!enemyModel.isAttack)
        {
            enemyModel.isAttack = true;
            enemyView.AttackPlayer();
            await new WaitForSeconds(enemyModel.timeBetweenAttacks);
            ResetAttack();
        }
    }

    private void ResetAttack()
    {
        enemyModel.isAttack = false;
    }
}
