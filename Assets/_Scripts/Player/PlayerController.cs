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
<<<<<<< Updated upstream
        private SimpleSpell[] _spells;

        private Transform _transform;
=======
        //временно SerializeField
        [SerializeField] private SimpleSpell[] _spells;
        [SerializeField] private Transform _castPoint;
        [SerializeField] private float _speed = 6.0f; // скорость персонажа
        [SerializeField] private float _rotationSpeed = 200.0f; // скорость персонажа
>>>>>>> Stashed changes
        private AudioSource _audioSource;
        private CharacterController _controller;
        


        private void Awake()
        {
            _audioSource = transform.GetComponent<AudioSource>();
<<<<<<< Updated upstream

=======
            _controller = GetComponent<CharacterController>();
>>>>>>> Stashed changes
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
                spell.Use(_castPoint);
                spell.UseEffects(_audioSource);
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
