using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour
{
    float rotateSpeed = 100.0f;

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.CompareTag("Key"))
            transform.Rotate(new Vector3(1,0,1) * rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && this.gameObject.CompareTag("Key"))
        {
            //Debug.Log("Key Collected");
            UIManager.Instance.keysCollected++;
            UIManager.Instance.UpdateScore(20);
            Destroy(this.gameObject);
        }
        else if(other.CompareTag("Player") && this.gameObject.CompareTag("Coin"))
        {
            //Debug.Log("Coin Collected");
            UIManager.Instance.coinsCollected++;
            UIManager.Instance.UpdateCoinsCollected();
            UIManager.Instance.UpdateScore(10);
            Destroy(this.gameObject);
        }
    }
}
