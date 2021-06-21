using System;
using AI.Enemies;
using AI.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AI
{
    public class MainWindowView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _countMoneyText;

        [SerializeField]
        private TMP_Text _countHealthText;

        [SerializeField]
        private TMP_Text _countPowerText;
        
        [SerializeField]
        private TMP_Text _crimeLevelText;

        [SerializeField]
        private TMP_Text _countPowerEnemyText;


        [SerializeField]
        private Button _addCoinsButton;

        [SerializeField]
        private Button _minusCoinsButton;


        [SerializeField]
        private Button _addHealthButton;

        [SerializeField]
        private Button _minusHealthButton;


        [SerializeField]
        private Button _addPowerButton;

        [SerializeField]
        private Button _minusPowerButton;
        
        [SerializeField]
        private Button _addCrimeButton;

        [SerializeField]
        private Button _minusCrimeButton;

        [SerializeField]
        private Button _fightButton;
        
        [SerializeField]
        private Button _passButton;

        public Action Fight;
        public Action Pass;
        public Action<int, DataType> ChangeDataWindow;
        
        private void Start()
        {
            _addCoinsButton.onClick.AddListener(() => ChangeMoney(true));
            _minusCoinsButton.onClick.AddListener(() => ChangeMoney(false));

            _addHealthButton.onClick.AddListener(() => ChangeHealth(true));
            _minusHealthButton.onClick.AddListener(() => ChangeHealth(false));

            _addPowerButton.onClick.AddListener(() => ChangePower(true));
            _minusPowerButton.onClick.AddListener(() => ChangePower(false));
            
            _addCrimeButton.onClick.AddListener(() => ChangeCrime(true));
            _minusCrimeButton.onClick.AddListener(() => ChangeCrime(false));

            _fightButton.onClick.AddListener(() => Fight());
            _fightButton.onClick.AddListener(() => Pass());
        }

        private void OnDestroy()
        {
            _addCoinsButton.onClick.RemoveAllListeners();
            _minusCoinsButton.onClick.RemoveAllListeners();

            _addHealthButton.onClick.RemoveAllListeners();
            _minusHealthButton.onClick.RemoveAllListeners();

            _addPowerButton.onClick.RemoveAllListeners();
            _minusPowerButton.onClick.RemoveAllListeners();
            
            _addCrimeButton.onClick.RemoveAllListeners();
            _minusCrimeButton.onClick.RemoveAllListeners();

            _fightButton.onClick.RemoveAllListeners();
        }

        private void ChangeMoney(bool isAddCount)
        {
            ChangeDataWindow?.Invoke(isAddCount ? 1 : -1, DataType.Money);
        }

        private void ChangeHealth(bool isAddCount)
        {
            ChangeDataWindow?.Invoke(isAddCount ? 1 : -1, DataType.Health);
        }

        private void ChangePower(bool isAddCount)
        {
            ChangeDataWindow?.Invoke(isAddCount ? 1 : -1, DataType.Power);
        }
        
        private void ChangeCrime(bool isAddCount)
        {
            ChangeDataWindow?.Invoke(isAddCount ? 1 : -1, DataType.Crime);
        }

        public void UpdatePlayerData(int countChangeData, DataType dataType)
        {
            switch (dataType)
            {
                case DataType.Money:
                    _countMoneyText.text = $"Player money {countChangeData.ToString()}";
                    break;
        
                case DataType.Health:
                    _countHealthText.text = $"Player health {countChangeData.ToString()}";
                    break;
        
                case DataType.Power:
                    _countPowerText.text = $"Player power {countChangeData.ToString()}";
                    break;
                case DataType.Crime:
                    _crimeLevelText.text = $"Player crime level {countChangeData.ToString()}";
                    break;
            }
        }

        public void UpdateEnemyData(int power)
        {
            _countPowerEnemyText.text = $"Enemy power {power}";
        }

        public void SetPassVisibility(bool value)
        {
            _passButton.gameObject.SetActive(value);
        }
    }
}