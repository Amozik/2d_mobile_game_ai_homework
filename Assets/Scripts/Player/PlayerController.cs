using System;
using AI.Data;
using AI.Enemies;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AI.Player
{
    public class PlayerController
    {
        private Money _money;
        private Health _heath;
        private Power _power;
        private Crime _crime;
        private GameObject _player;

        public int Money => _money.CountMoney;
        public int Health => _heath.CountHealth;
        public int Power => _power.CountPower;
        public int Crime => _crime.CrimeLevel;

        public PlayerController(PlayerConfig _playerConfig)
        {
            _player = Object.Instantiate(_playerConfig.view);

            _money = new Money(nameof(Money));
            _money.CountMoney = _playerConfig.startMoney;
            
            _heath = new Health(nameof(Health))
            {
                CountHealth = _playerConfig.startHealth
            };
            _power = new Power(nameof(Power))
            {
                CountPower = _playerConfig.startPower
            };
            _crime = new Crime(nameof(Crime))
            {
                CrimeLevel = _playerConfig.startCrimeLevel
            };
        }
        
        public void ChangeData(int countChangeData, DataType dataType, Action<int> callback)
        {
            switch (dataType)
            {
                case DataType.Money:
                    _money.CountMoney += countChangeData;
                    callback?.Invoke(_money.CountMoney);
                    break;

                case DataType.Health:
                    _heath.CountHealth += countChangeData;
                    callback?.Invoke(_heath.CountHealth);
                    break;

                case DataType.Power:
                    _power.CountPower += countChangeData;
                    callback?.Invoke(_power.CountPower);
                    break;
                case DataType.Crime:
                    _crime.CrimeLevel += countChangeData;
                    callback?.Invoke(_crime.CrimeLevel);
                    break;
            }
        }

        public void AttachEnemy(IEnemy enemy)
        {
            _money.Attach(enemy);
            _heath.Attach(enemy);
            _power.Attach(enemy);
            //_crime.Attach(enemy);
        }

        public void DetachEnemy(IEnemy enemy)
        {
            _money.Detach(enemy);
            _heath.Detach(enemy);
            _power.Detach(enemy);
            //_crime.Detach(enemy);
        }
    }
}