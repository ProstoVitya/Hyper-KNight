using UnityEngine;
using Usables;
using Usables.Spells;
using Utilities.Observer;

namespace Player
{
    [RequireComponent(typeof(AudioSource))]
    public class PlayerController : Subject
    {
        private SimpleSpell[] _spells;

        private Transform _transform;
        private AudioSource _audioSource;

        private void Awake()
        {
            _transform = transform;
            _audioSource = transform.GetComponent<AudioSource>();

            //todo: подгружать выбранные в меню способности
        }

        /// <summary>
        /// Использует способность
        /// </summary>
        /// <param name="index">Номер элемента в UI</param>
        public void UseSpell(int index)
        {
            var spell = _spells[index];

            if (spell.TimeToNextAttack <= 0)
            {
                spell.Use(_transform);
                spell.UseEffects(_audioSource);
            }
        }
    }
}
