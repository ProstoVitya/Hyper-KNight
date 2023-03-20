using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Usables.Spells
{
    public class HealSpell : SimpleSpell
    {
        [SerializeField] private float _healAmount = 10f;
        [SerializeField] private ParticleSystem _particles;

        protected override void UseSpell(Transform transform)
        {
            HealthComponent Health = transform.GetComponentInParent<HealthComponent>();
            Instantiate(_particles, transform.position, transform.rotation);
            Health.Heal(_healAmount);
        }
    }
}
