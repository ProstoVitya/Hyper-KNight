using System;
using System.Collections;
using Managers;
using Scriptables;
using UnityEngine;
using Utilities;
using Utilities.Observer;

namespace Enemies
{
    public abstract class BaseEnemy : Subject

    {
        protected readonly Vector3 _playerPosition;

        [SerializeField] protected Stats _baseStats;

        [Header("Animations")]
        [SerializeField] private Animation _attackAnimation;
        [SerializeField] private Animation _moveAnimation;
        [SerializeField] private Animation _reloadAnimation;

        protected float _currentCooldown;

        protected BaseEnemy(int level)
        {
            var player = GameObject.FindWithTag(GameConstants.PlayerTag);
            _playerPosition = player.transform.position;
            Level = level;
            _currentCooldown = 0;
        }

        protected int Level { get; }

        public abstract EnemyType EnemyType { get; }
        public virtual float Health => _baseStats.Health * Level;
        public virtual float Damage => _baseStats.Damage * Level;

        protected virtual bool CanAttack =>
            Vector3.Distance(_playerPosition, transform.position) <= _baseStats.AttackDistance;

        protected virtual void Attack()
        {
            
        }

        protected virtual void Reload()
        {
            _currentCooldown -= Time.deltaTime;
        }
        
        protected abstract void Move();

        private void Update()
        {
            if (CanAttack)
            {
                _attackAnimation.Play();
                Attack();
                _currentCooldown = _baseStats.AttackCooldown;
            }
            else if(_currentCooldown >= 0)
            {
                _reloadAnimation?.Play();
                Reload();
            }
            else
            {
                _moveAnimation.Play();
                Move();
            }
        }
    }
}
