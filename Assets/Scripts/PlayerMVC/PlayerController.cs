using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    public PlayerView _playerView;
    public PlayerModel _playerModel;

    float rotationInput, movementInput;

    public PlayerController(PlayerView _playerView, PlayerModel _playerModel)
    {
        Transform _playerTransform = SpawnManager.Instance.GetPlayerSpawnPosition();
        this._playerModel = _playerModel;
        this._playerView = GameObject.Instantiate<PlayerView>(_playerView, _playerTransform.position, _playerTransform.rotation);
        this._playerView.SetPlayerController(this);
        PlayerHealthController.Instance.InitializeSlider(this._playerModel.health);
    }

    public void PlayerMovement()
    {
        rotationInput = Input.GetAxis("Horizontal") * _playerModel.rotationSpeed * Time.deltaTime;
        movementInput = Input.GetAxis("Vertical") * _playerModel.speed * Time.deltaTime;

        if ((rotationInput > 0 || rotationInput < 0 || movementInput > 0))
        {
            _playerView.transform.Translate(0, 0, movementInput);
            _playerView.playerAnimator.SetFloat("Speed", 0.2f);
            _playerView.playerAnimator.SetBool("Running", true);
            _playerView.transform.Rotate(0, rotationInput, 0);
        }
        else
        {
            _playerView.playerAnimator.SetFloat("Speed", 0.0f);
        }

        if (movementInput < 0 && !_playerView.playerAnimator.GetBool("Running Backwards"))
        {
            _playerView.transform.Translate(0, 0, movementInput);
            _playerView.playerAnimator.SetBool("Running Backwards", true);
        }
        else
        {
            _playerView.playerAnimator.SetBool("Running Backwards", false);
        }
    }

    public void PlayerAttack()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _playerModel.isAttacking = true;
            _playerView.playerAnimator.SetTrigger("Attack");         
        }      
    }

    public void UpdateHealth(int damage)
    {
        if ((_playerModel.health - damage) <= 0 && !_playerModel.isDead)
        {
            _playerModel.isDead = true;
            _playerView.PlayerDeath();
        }
        else
        {
            PlayerHealthController.Instance.UpdateSliderValue(damage);
            _playerModel.health -= damage;
        }
    }
}
