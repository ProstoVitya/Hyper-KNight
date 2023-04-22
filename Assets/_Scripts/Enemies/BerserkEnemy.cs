using Managers;

namespace Enemies
{
    public class BerserkEnemy : BaseEnemy
    {
        public BerserkEnemy(int level) : base(level)
        {
        }

        public override EnemyType EnemyType => EnemyType.Berserk;
        
        protected override void Attack()
        {
            throw new System.NotImplementedException();
        }

        protected override void Move()
        {
            throw new System.NotImplementedException();
        }
    }
}