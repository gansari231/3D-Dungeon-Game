using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : SingletonGeneric<SpawnManager>
{
    [SerializeField]
    Transform _playerSpawnPoint;
    [SerializeField]
    Transform[] quarter1 = new Transform[3];
    [SerializeField]
    Transform[] quarter2 = new Transform[3];
    [SerializeField]
    Transform[] quarter3 = new Transform[3];

    public Transform GetRandomSpawnPoint()
    {
        int quarterNumber = Random.Range(1, 4);
        int transformNumber = Random.Range(0, 3);

        switch (quarterNumber)
        {
            case 1:
                return quarter1[transformNumber];

            case 2:
                return quarter2[transformNumber];

            case 3:
                return quarter3[transformNumber];
        }
        return quarter1[transformNumber];
    }

    public Transform GetPlayerSpawnPosition()
    {
        return _playerSpawnPoint;
    }
}
