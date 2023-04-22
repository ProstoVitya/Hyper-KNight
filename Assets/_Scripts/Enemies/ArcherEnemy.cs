using System;
using System.Collections;
using Managers;
using UnityEngine;

namespace Enemies
{
    public class ArcherEnemy : BaseEnemy
    {
        [SerializeField] private int _maxArrowsCount;
        [SerializeField] private GameObject _arrow;
        private int _arrowsCount;
        
        public ArcherEnemy(int level) : base(level)
        {
            _arrowsCount = _maxArrowsCount;
        }
        
        public override EnemyType EnemyType => EnemyType.Archer;
        protected override bool CanAttack => base.CanAttack && _arrowsCount > 0;


        protected override void Attack()
        {
            var arrow = Instantiate(_arrow, transform);
            StartCoroutine(ShootArrow(arrow, _playerPosition));
        }

        protected override void Move()
        {
            throw new NotImplementedException();
        }

        protected override void Reload()
        {
            base.Reload();
            if (_currentCooldown <= 0 && _arrowsCount <= _maxArrowsCount)
            {
                ++_arrowsCount;
            }
        }

        private IEnumerator ShootArrow(GameObject arrow, Vector3 playerPosition)
        {
            while (arrow.transform.position != playerPosition)
            {
                arrow.transform.position += arrow.transform.forward * 0.01f;
                yield return new WaitForEndOfFrame();   
            }
        }
    }
}