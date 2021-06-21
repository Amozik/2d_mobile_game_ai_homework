using System;
using AI.Enemies;
using AI.Player;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AI
{
    public class MainWindowController : IDisposable
    {
        private MainWindowView _mainWindowView;
        private PlayerController _playerController;
        private Enemy _enemy;

        public MainWindowController(MainWindowView view, PlayerController playerController, Enemy enemy)
        {
            _playerController = playerController;
            _enemy = enemy;
            
            _mainWindowView = Object.Instantiate(view);
            _mainWindowView.ChangeDataWindow += ChangeDataWindow;
            _mainWindowView.Fight += Fight;
            _mainWindowView.Pass += Pass;
            _mainWindowView.UpdatePlayerData(_playerController.Money, DataType.Money);
            _mainWindowView.UpdatePlayerData(_playerController.Health, DataType.Health);
            _mainWindowView.UpdatePlayerData(_playerController.Power, DataType.Power);
            _mainWindowView.UpdatePlayerData(_playerController.Crime, DataType.Crime);
            _mainWindowView.SetPassVisibility(_playerController.Crime > 2);
            _mainWindowView.UpdateEnemyData(_enemy.Power);
        }
        
        private void Fight()
        {
            Debug.Log(_playerController.Power >= _enemy.Power
                ? "<color=#07FF00>Win!!!</color>"
                : "<color=#FF0000>Lose!!!</color>");
        }
        
        private void Pass()
        {
            Debug.Log("You passed by");
        }

        private void ChangeDataWindow(int value, DataType dataType)
        {
            _playerController.ChangeData(value, dataType, OnChange);

            void OnChange(int changedValue)
            {
                _mainWindowView.UpdatePlayerData(changedValue, dataType);
                
                if (dataType == DataType.Crime)
                {
                    _mainWindowView.SetPassVisibility(changedValue > 2);
                }
            }
            
            _mainWindowView.UpdateEnemyData(_enemy.Power);
        }

        public void Dispose()
        {
            _mainWindowView.Fight -= Fight;
            _mainWindowView.Pass -= Pass;
        }
    }
}