using AI.Player;
using UnityEditor;

namespace AI.Enemies
{
    public interface IEnemy
    {
        void Update(DataPlayer dataPlayer, DataType dataType);
    }
}