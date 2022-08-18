using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : SingletonGeneric<UIManager>
{
    [SerializeField]
    GameObject _levelComponents;
    [SerializeField]
    GameObject _scoreCollectablesPanel;
    [SerializeField]
    GameObject _mainMenuPanel;
    [SerializeField]
    GameObject _instructionsPanel;
    [SerializeField]
    GameObject _nameReminderPanel;
    [SerializeField]
    GameObject _finalScorePanel;

    [SerializeField]
    Camera _tempCamera;
    [SerializeField]
    TMP_InputField _nameInputField;
    [SerializeField]
    TextMeshProUGUI _coinsText;
    [SerializeField]
    TextMeshProUGUI _scoreText;

    [HideInInspector]
    public bool startSpawning;
    [HideInInspector]
    public int score, coinsCollected, keysCollected, enemiesKilled;

    [SerializeField]
    PlayerView _playerPrefab;

    public void StartGame()
    {
        if(_nameInputField.text == "")
        {
            _mainMenuPanel.SetActive(false);
            _nameReminderPanel.SetActive(true);
        }
        else
        {
            _mainMenuPanel.SetActive(false);
            _tempCamera.gameObject.SetActive(false);
            _levelComponents.SetActive(true);
            _scoreCollectablesPanel.SetActive(true);
            _playerPrefab.gameObject.SetActive(true);
            EnemyService.Instance.StartSpawning();
        }     
    }

    public void DisplayInstructionPanel()
    {
        _mainMenuPanel.SetActive(false);
        _instructionsPanel.SetActive(true);
    }

    public void CrossButtonEvent()
    {
        _instructionsPanel.SetActive(false);
        _nameReminderPanel.SetActive(false);
        _finalScorePanel.SetActive(false);
        _mainMenuPanel.SetActive(true);
    }

    public void UpdateCoinsCollected()
    {
        _coinsText.text = " :" + coinsCollected;
    }

    public void UpdateScore(int points)
    {
        score += points;
        _scoreText.text = "Score : " + score;
    }
}
