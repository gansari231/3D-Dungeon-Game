using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && EnemyService.Instance._enemyController._enemyModel.isAttack)
        {
            PlayerService.Instance._playerController._playerView.TakeDamage(EnemyService.Instance._enemyController._enemyModel.damage);
        }
    }
}
