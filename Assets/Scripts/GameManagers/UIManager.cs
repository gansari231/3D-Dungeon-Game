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
    [SerializeField]
    TextMeshProUGUI _totalCoinsText;
    [SerializeField]
    TextMeshProUGUI _totalScoreText;
    [SerializeField]
    TextMeshProUGUI _totalEnemiesKilledText;
    [SerializeField]
    TextMeshProUGUI _totalKeysText;
    [SerializeField]
    TextMeshProUGUI _playerNameText;

    [HideInInspector]
    public bool startSpawning;
    [HideInInspector]
    public int score, coinsCollected, keysCollected, enemiesKilled;

    void ResetAssets()
    {
        score = 0;
        coinsCollected = 0;
        keysCollected = 0;
        enemiesKilled = 0;
        _coinsText.text = " :";
        _scoreText.text = "Score : ";
        _nameInputField.text = "";
    }

    public void StartGame()
    {
        if (_nameInputField.text == "")
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
            PlayerService.Instance.SpawnPlayer();
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

    public void GameOver()
    {
        _finalScorePanel.SetActive(true);
        _totalCoinsText.text += coinsCollected;
        _totalEnemiesKilledText.text += enemiesKilled;
        _totalKeysText.text += keysCollected;
        _totalScoreText.text += score;
        _playerNameText.text += _nameInputField.text;

        StartCoroutine(GameEndSequence());     
    }

    IEnumerator GameEndSequence()
    {
        yield return new WaitForSeconds(8.0f);
        ResetAssets();
        MainMenu();
    }

    void MainMenu()
    {
        _finalScorePanel.SetActive(false);
        _levelComponents.SetActive(false);
        _scoreCollectablesPanel.SetActive(false);
        PlayerService.Instance._playerController._playerView.gameObject.SetActive(false);
        _mainMenuPanel.SetActive(true);
        _tempCamera.gameObject.SetActive(true);  
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
