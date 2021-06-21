using System.Collections.Generic;
using AI.Enemies;

namespace AI.Player
{
    public class DataPlayer
    {
        private string _titleData;
        private int _countMoney;
        private int _countHealth;
        private int _countPower;
        private int _crimeLevel;

        private List<IEnemy> _enemies = new List<IEnemy>();

        public string TitleData => _titleData;

        public int CountMoney
        {
            get => _countMoney;
            set
            {
                if (_countMoney != value)
                {
                    _countMoney = value;
                    Notify(DataType.Money);
                }
            }
        }

        public int CountHealth
        {
            get => _countHealth;
            set
            {
                if (_countHealth != value)
                {
                    _countHealth = value;
                    Notify(DataType.Health);
                }
            }
        }

        public int CountPower
        {
            get => _countPower;
            set
            {
                if (_countPower != value)
                {
                    _countPower = value;
                    Notify(DataType.Power);
                }
            }
        }
        
        public int CrimeLevel
        {
            get => _crimeLevel;
            set
            {
                if (_crimeLevel != value)
                {
                    _crimeLevel = value;
                    Notify(DataType.Crime);
                }
            }
        }

        public DataPlayer(string titleData)
        {
            _titleData = titleData;
        }

        public void Attach(IEnemy enemy)
        {
            _enemies.Add(enemy);

            OnAttach(enemy);
        }

        public void Detach(IEnemy enemy)
        {
            _enemies.Remove(enemy);
        }

        private void Notify(DataType dataType)
        {
            foreach (var enemy in _enemies)
                enemy.Update(this, dataType);
        }

        protected virtual void OnAttach(IEnemy enemy)
        {
            
        }
    }
}