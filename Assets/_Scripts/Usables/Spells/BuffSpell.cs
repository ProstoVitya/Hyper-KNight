using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Usables.Spells
{
    public class BuffSpell : SimpleSpell
    {
        [SerializeField] private float _armorBoost = 10f;
        [SerializeField] private float _damageBoost = 10f;
        protected override void UseSpell(Transform transform)
        {
            Debug.Log("zabafalsa tipo +10, +10 XDDDDDD");
            //реализовать +армор +урон или еще что-то
        }
    }
}
