using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService : SingletonGeneric<EnemyService>
{
    [SerializeField]
    EnemyView _enemyView;
    int num = 3;
    public EnemyController _enemyController;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 2; i++)
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
