using UnityEngine;

namespace Usables.Spells
{
    public class FireballSpell : SimpleSpell
    {
        [SerializeField] private GameObject fireball;
        protected override void UseSpell(Transform transform)
        {
            Instantiate(fireball, transform.position, transform.rotation);
        }
    }
}