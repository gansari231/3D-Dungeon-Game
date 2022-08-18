using UnityEngine;

public class EnemyController
{
    public EnemyView _enemyView;
    public EnemyModel _enemyModel;

    public EnemyController(EnemyView enemyView, EnemyModel enemyModel)
    {
        Transform enemyTransform = SpawnManager.Instance.GetRandomSpawnPoint();
        this._enemyModel = enemyModel;
        _enemyView = GameObject.Instantiate<EnemyView>(enemyView, enemyTransform.transform.position, enemyTransform.transform.rotation);
        this._enemyView.SetEnemyController(this);
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
