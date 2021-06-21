using System;
using AI.Data;
using AI.Enemies;
using AI.Player;
using UnityEngine;

namespace AI
{
    public class GameEntry : MonoBehaviour, IDisposable
    {
        [SerializeField] 
        private GameConfig _gameConfig;

        private PlayerController _playerController;
        private Enemy _enemy;
        private MainWindowController _mainWindowController;

        private void Awake()
        {
            _playerController = new PlayerController(_gameConfig.playerConfig);
            _enemy = new Enemy("my enemy", _gameConfig.enemyView);
            _playerController.AttachEnemy(_enemy);

            _mainWindowController = new MainWindowController(_gameConfig.mainWindowView, _playerController, _enemy);
        }

        public void Dispose()
        {
            _playerController.DetachEnemy(_enemy);
        }
    }
}