using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Usables.Spells
{
    public class HealSpell : SimpleSpell
    {
        [SerializeField] private float _healAmount = 10f;
        [SerializeField] private GameObject _particles;

        protected override void UseSpell(Transform transform)
        {
            HealthComponent Health = transform.GetComponentInParent<HealthComponent>();
            GameObject spawnedObject = Instantiate(_particles, transform.position, transform.rotation);
            Destroy(spawnedObject, 0.5f);
            Health.Heal(_healAmount);
        }
    }
}
