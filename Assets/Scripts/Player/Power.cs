using AI.Enemies;

namespace AI.Player
{
    public class Power: DataPlayer
    {
        public Power(string titleData) : base(titleData)
        {

        }
        
        protected override void OnAttach(IEnemy enemy)
        {
            enemy.Update(this, DataType.Power);
        }
    }
}