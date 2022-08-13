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
        this._playerView = _playerView;
        this._playerModel = _playerModel;
        this._playerView.SetPlayerController(this);
    }

    public void PlayerMovement()
    {
        rotationInput = Input.GetAxis("Horizontal") * _playerModel.rotationSpeed * Time.deltaTime;
        movementInput = Input.GetAxis("Vertical") * _playerModel.speed * Time.deltaTime;

        if ((rotationInput > 0 || rotationInput < 0 || movementInput > 0 || movementInput < 0))
        {
            _playerView.transform.Translate(0, 0, movementInput);
            _playerView.player_Animator.SetFloat("Speed", 0.2f);
            _playerView.player_Animator.SetBool("Running", true);

            _playerView.transform.Rotate(0, rotationInput, 0);
        }
        else
        {
            _playerView.player_Animator.SetFloat("Speed", 0.0f);
        }
            

    }

    public void PlayerAttack()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            _playerView.player_Animator.SetBool("Attack", true);
        }
        else
        {
            _playerView.player_Animator.SetBool("Attack", false);
        }
    }
}
