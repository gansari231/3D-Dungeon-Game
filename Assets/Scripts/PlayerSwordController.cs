using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwordController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy Body"))
        {
            EnemyService.Instance._enemyController._enemyView.TakeDamage(PlayerService.Instance._playerController._playerModel.damage);
        }
    }
}
