using UnityEngine;

namespace AI.Data
{
    [CreateAssetMenu(fileName = nameof(PlayerConfig), menuName = "Configs/" + nameof(PlayerConfig), order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        public GameObject view;
        public int startMoney = 200;
        public int startHealth = 50;
        public int startPower = 20;
        public int startCrimeLevel = 2;
    }
}