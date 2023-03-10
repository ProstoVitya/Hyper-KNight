using UnityEngine;

namespace Usables.Spells
{
    public abstract class SimpleSpell : MonoBehaviour, IUsable
    {
        [Header("Parameters")]
        [SerializeField] private float _cooldown;
        [SerializeField] private Collider _attackForm;

        [Header("Effects")]
        [SerializeField] private AudioClip _sound;
        [SerializeField] private ParticleSystem _particles;

        private float _timeToNextAttack;
        
        public float Cooldown => _cooldown;
        
        /// <summary>
        /// Метод использует эффект, но не создает визуальных и аудио эффектов
        /// При желании использовать эффекты их необходимо вызывать из использующего обхекта
        /// </summary>
        /// <param name="usingObjectTransform"></param>
        public void Use(Transform usingObjectTransform = null)
        {
            if (TimeToNextAttack > 0)
            {
                return;
            }
            UseSpell(transform);
            _timeToNextAttack = Cooldown;
        }

        public float TimeToNextAttack => _timeToNextAttack;

        protected abstract void UseSpell(Transform transform);

        public virtual void UseEffects(AudioSource audioSource)
        {
            _particles?.Play();
            if (_sound != null)
            {
                audioSource.PlayOneShot(_sound);
            }
        }

        private void FixedUpdate()
        {
            if (_timeToNextAttack > 0)
            {
                _timeToNextAttack -= Time.fixedDeltaTime;
            }
        }
    }
}