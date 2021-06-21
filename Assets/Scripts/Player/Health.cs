using AI.Enemies;

namespace AI.Player
{
    public class Health : DataPlayer
    {
        public Health(string titleData) : base(titleData)
        {

        }

        protected override void OnAttach(IEnemy enemy)
        {
            enemy.Update(this, DataType.Health);
        }
    }
}