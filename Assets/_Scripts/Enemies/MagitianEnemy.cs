using Managers;

namespace Enemies
{
    public class MagitianEnemy : BaseEnemy
    {
        public MagitianEnemy(int level) : base(level)
        {
        }

        public override EnemyType EnemyType => EnemyType.Magitian;

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