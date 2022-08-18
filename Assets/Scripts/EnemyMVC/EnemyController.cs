using UnityEngine;

public class EnemyController
{
    public EnemyView _enemyView;
    public EnemyModel _enemyModel;

    public EnemyController(EnemyView enemyView, EnemyModel enemyModel)
    {
        this._enemyView = enemyView;
        this._enemyModel = enemyModel;
        this._enemyView.SetEnemyController(this);
        //this.enemyView.OnDrawGizmos();
    }

    public void RangeCheck()
    {
        _enemyModel.inChaseRange = Physics.CheckSphere(_enemyView.transform.position, _enemyModel.chaseRange, _enemyView.playerLayerMask);
        _enemyModel.inAttackRange = Physics.CheckSphere(_enemyView.transform.position, _enemyModel.attackRange, _enemyView.playerLayerMask);
    }

    public void UpdateHealth(int damage)
    {
        if ((_enemyModel.health - damage) <= 0)
        {
            GameObject.Destroy(_enemyView.gameObject);
        }
        else
        {
            _enemyModel.health -= damage;
        }
        Debug.Log("Enemy Updated Health: " + _enemyModel.health);
    }
}
