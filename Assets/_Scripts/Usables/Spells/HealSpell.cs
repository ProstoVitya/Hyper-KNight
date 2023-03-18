using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Usables.Spells
{
    public class HealSpell : SimpleSpell
    {
        [SerializeField] private float _healAmount = 10f;
        protected override void UseSpell(Transform transform)
        {
            Debug.Log("voshel");
            HealthComponent Health = transform.GetComponentInParent<HealthComponent>();
            Health.Heal(_healAmount);
        }
    }
}
