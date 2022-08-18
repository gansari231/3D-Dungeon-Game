using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService : SingletonGeneric<EnemyService>
{
    [SerializeField]
    EnemyView _enemyView;
    [SerializeField]
    int enemyCount = 3;
    public EnemyController _enemyController;

    public void StartSpawning()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            CreateEnemy();
        }           
    }

    void CreateEnemy()
    {
        EnemyModel _enemyModel = new EnemyModel();
        _enemyController = new EnemyController(_enemyView, _enemyModel);
    }
}
