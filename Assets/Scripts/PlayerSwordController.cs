using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwordController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyService.Instance._enemyController._enemyView.TakeDamage(PlayerService.Instance._playerController._playerModel.damage);
            PlayerService.Instance._playerController._playerModel.isAttacking = false;
        }
    }
}
