using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [HideInInspector]
    public Animator player_Animator;
    PlayerController _playerController;

    void Start()
    {
        player_Animator = GetComponent<Animator>();
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

    
}
