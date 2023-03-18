using UnityEngine;

namespace Usables.Spells
{
    public abstract class SimpleSpell : MonoBehaviour, IUsable
    {
        [Header("Parameters")]
        [SerializeField] private float _cooldown;

        [Header("Effects")]
        [SerializeField] private AudioClip _sound;
        [SerializeField] private ParticleSystem _particles;

        private float _timeToNextUse;
        
        public float Cooldown => _cooldown;
        
        /// <summary>
        /// Метод использует эффект, но не создает визуальных и аудио эффектов
        /// При желании использовать эффекты их необходимо вызывать из использующего обхекта
        /// </summary>
        /// <param name="usingObjectTransform"></param>
        public void Use(Transform usingObjectTransform = null)
        {
            if (TimeToNextUse > 0)
            {
                return;
            }
            UseSpell(usingObjectTransform);
            _timeToNextUse = Cooldown;
        }

        public float TimeToNextUse => _timeToNextUse;

        protected abstract void UseSpell(Transform transform);

        public virtual void UseEffects(AudioSource audioSource)
        {
            if(_particles != null)
                _particles?.Play();
            if (_sound != null)
            {
                audioSource.PlayOneShot(_sound);
            }
        }

        private void FixedUpdate()
        {
            if (_timeToNextUse > 0)
            {
                _timeToNextUse -= Time.fixedDeltaTime;
            }
        }
    }
}