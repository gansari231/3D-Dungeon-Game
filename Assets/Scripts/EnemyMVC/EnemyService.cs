using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService : SingletonGeneric<EnemyService>
{
    [SerializeField]
    EnemyView _enemyView;
    [SerializeField]
    public int enemyCount;
    public EnemyController _enemyController;

    public void StartSpawning()
    {
        CreateEnemy();         
    }

    void CreateEnemy()
    {
        EnemyModel _enemyModel = new EnemyModel();
        _enemyController = new EnemyController(_enemyView, _enemyModel);
    }
}
