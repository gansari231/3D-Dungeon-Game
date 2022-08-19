using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndController : MonoBehaviour
{
    [SerializeField]
    GameObject _keysReminder;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") && UIManager.Instance.keysCollected == 3)
        {
            UIManager.Instance.GameOver();
        }
        else
        {
            _keysReminder.SetActive(true);
            StartCoroutine(ReminderTimer());
        }
    }

    IEnumerator ReminderTimer()
    {
        yield return new WaitForSeconds(5.0f);
        _keysReminder.SetActive(false);
    }
}
