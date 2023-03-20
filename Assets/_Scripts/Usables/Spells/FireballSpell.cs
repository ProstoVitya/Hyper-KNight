using UnityEngine;

namespace Usables.Spells
{
    public class FireballSpell : SimpleSpell
    {
        [SerializeField] private GameObject _fireball;
        protected override void UseSpell(Transform transform)
        {
            Vector3 position = transform.position;
            position += transform.forward*1.5f;
            Instantiate(_fireball, position, transform.rotation);
        }
    }
}