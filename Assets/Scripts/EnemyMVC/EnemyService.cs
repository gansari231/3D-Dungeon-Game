using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService : SingletonGeneric<EnemyService>
{
    [SerializeField]
    EnemyView _enemyView;
    public EnemyController _enemyController;

    // Start is called before the first frame update
    void Start()
    {
        CreateEnemy();
    }

    void CreateEnemy()
    {
        EnemyModel _enemyModel = new EnemyModel();
        _enemyController = new EnemyController(_enemyView, _enemyModel);
    }
}
