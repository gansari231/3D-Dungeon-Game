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
        if(_enemyModel.isAlive)
        {
            _enemyModel.inChaseRange = Physics.CheckSphere(_enemyView.transform.position, _enemyModel.chaseRange, _enemyView.playerLayerMask);
            _enemyModel.inAttackRange = Physics.CheckSphere(_enemyView.transform.position, _enemyModel.attackRange, _enemyView.playerLayerMask);
        }      
    }

    public void UpdateHealth(int damage)
    {
        if((_enemyModel.health - damage) <= 0 && _enemyModel.isAlive)
        {
            _enemyModel.health -= damage;
            _enemyModel.isAlive = false;
            _enemyView.enemyAnimator.SetTrigger("Death");
            UIManager.Instance.enemiesKilled++;
            UIManager.Instance.UpdateScore(40);
            if(UIManager.Instance.enemiesKilled < EnemyService.Instance.enemyCount)
                EnemyService.Instance.StartSpawning();
            //_enemyView.gameObject.SetActive(false);
            //GameObject.Destroy(_enemyView.gameObject);
        }
        else if(_enemyModel.isAlive)
        {
            _enemyView.EnemyHurt();
            _enemyModel.health -= damage;
            Debug.Log("Enemy Health: " + _enemyModel.health);
        }
        
    }
}
