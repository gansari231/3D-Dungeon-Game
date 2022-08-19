using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [HideInInspector]
    public Animator playerAnimator;
    PlayerController _playerController;
    [SerializeField]
    GameObject _playerHealthSliderPanel;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        _playerHealthSliderPanel.SetActive(true);
    }

    void FixedUpdate()
    {
        _playerController.PlayerMovement();
        _playerController.PlayerAttack();
    }

    public void SetPlayerController(PlayerController _playerController)
    {
        this._playerController = _playerController;
    }

    public void TakeDamage(int damage)
    {
        PlayerHurt();
        _playerController.UpdateHealth(damage);
    }

    void PlayerHurt()
    {
        playerAnimator.SetTrigger("Hurt");
    }

    public void PlayerDeath()
    {      
        playerAnimator.SetTrigger("Die");
        UIManager.Instance.GameOver();
    }
}
