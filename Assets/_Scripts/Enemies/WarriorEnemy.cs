using Managers;

namespace Enemies
{
    public class WarriorEnemy : BaseEnemy
    {
        public WarriorEnemy(int level) : base(level)
        {
        }

        public override EnemyType EnemyType => EnemyType.Warrior;

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