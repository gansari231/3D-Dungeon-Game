using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : SingletonGeneric<PlayerHealthController>
{  
    int _currentHealth;
    [SerializeField]
    Slider playerHealthSlider;
    [SerializeField]
    Image _healthFill;

    public void InitializeSlider(int playerHealth)
    {
        _currentHealth = playerHealth;
        playerHealthSlider.maxValue = playerHealth;
        playerHealthSlider.value = _currentHealth;
    }

    public void UpdateSliderValue(int damage)
    {
        if (_currentHealth - damage >= 0)
        {
            _currentHealth -= damage;
            playerHealthSlider.value = _currentHealth;
            Debug.Log("Player health : " + _currentHealth);
        }
    }
}
