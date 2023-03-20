using UnityEngine;
using Usables;
using Usables.Spells;
using Utilities.Observer;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(AudioSource))]
    public class PlayerController : Subject
    {
        //временно SerializeField
        [SerializeField] private SimpleSpell[] _spells;
        [SerializeField] private float _speed = 6.0f; // скорость персонажа
        [SerializeField] private float _rotationSpeed = 200.0f; // скорость персонажа
        private AudioSource _audioSource;
        private CharacterController _controller;



        private void Awake()
        {
            _audioSource = transform.GetComponent<AudioSource>();
            _controller = GetComponent<CharacterController>();
            //todo: подгружать выбранные в меню способности
        }

        /// <summary>
        /// Использует способность
        /// </summary>
        /// <param name="index">Номер элемента в UI</param>
        public void UseSpell(int index)
        {
            var spell = _spells[index];

            if (spell.TimeToNextUse <= 0)
            {
                spell.Use(transform);
                spell.UseEffects(_audioSource);
                NotifyObservers((PlayerAction)index);
            }
        }
        private void Update()
        {
            float vertical = Input.GetAxis("Vertical");
            float rotation = Input.GetAxis("Horizontal") * _rotationSpeed * Time.deltaTime;
            transform.Rotate(0, rotation, 0);
            Vector3 move = transform.forward * vertical * _speed;
            _controller.Move(move * Time.deltaTime);
        }
    }
}
