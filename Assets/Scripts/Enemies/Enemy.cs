using AI.Player;
using UnityEngine;

namespace AI.Enemies
{
    public class Enemy : IEnemy
    {
        private const int KCoins = 5;
        private const float KPower = 1.5f;
  
        private string _name;
        private int _moneyPlayer;
        private int _healthPlayer;
        private int _powerPlayer;

        public Enemy(string name, GameObject view)
        {
            _name = name;
            Object.Instantiate(view);
        }

        public void Update(DataPlayer dataPlayer, DataType dataType)
        {
            switch (dataType)
            {
                case DataType.Money:
                    _moneyPlayer = dataPlayer.CountMoney;
                    break;
          
                case DataType.Health:
                    _healthPlayer = dataPlayer.CountHealth;
                    break;
          
                case DataType.Power:
                    _powerPlayer = dataPlayer.CountPower;
                    break;
            }
      
            Debug.Log($"Notified {_name} change to {dataPlayer}");
        }

        public int Power
        {
            get
            {
                var kHealth = _healthPlayer % 100 + 1;
                var power = (int) (_moneyPlayer * KCoins + _powerPlayer * KPower) / kHealth;
          
                return power;
            }
        }

    }
}