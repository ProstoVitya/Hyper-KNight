using Managers;

namespace Enemies
{
    public class SlimeEnemy : BaseEnemy
    {
        public SlimeEnemy(int level) : base(level)
        {
        }

        public override EnemyType EnemyType => EnemyType.Slime;

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