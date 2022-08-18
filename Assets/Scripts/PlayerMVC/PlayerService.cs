using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerService : SingletonGeneric<PlayerService>
{
    [SerializeField]
    PlayerView _playerView;
    public PlayerController _playerController;

    public void SpawnPlayer()
    {
        CreatePlayer();
    }

    void CreatePlayer()
    {
        PlayerModel _playerModel = new PlayerModel();
        _playerController = new PlayerController(_playerView, _playerModel);
    }
}
