using AI.Enemies;

namespace AI.Player
{
    public class Money : DataPlayer
    {
        public Money(string titleData) : base (titleData)
        {

        }
        
        protected override void OnAttach(IEnemy enemy)
        {
            enemy.Update(this, DataType.Money);
        }
    }
}