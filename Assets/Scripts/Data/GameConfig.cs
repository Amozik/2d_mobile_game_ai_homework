using UnityEngine;

namespace AI.Data
{
    [CreateAssetMenu(fileName = nameof(GameConfig),  menuName = "Configs/" + nameof(GameConfig), order = 0)]
    public class GameConfig : ScriptableObject
    {
        public PlayerConfig playerConfig;
        public GameObject enemyView;
        public MainWindowView mainWindowView;
    }
}