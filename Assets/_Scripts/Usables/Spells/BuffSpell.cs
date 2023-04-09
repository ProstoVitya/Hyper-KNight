using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Usables.Spells
{
    public class BuffSpell : SimpleSpell
    {
        [SerializeField] private float _armorBoost = 10f;
        [SerializeField] private float _damageBoost = 10f;
        [SerializeField] private GameObject _particles;
        protected override void UseSpell(Transform transform)
        {
            GameObject spawnedObject = Instantiate(_particles, transform.position, transform.rotation);
            spawnedObject.transform.parent = transform;
            Destroy(spawnedObject, 6f);
            Debug.Log("zabafalsa tipo +10, +10 XDDDDDD");
            //реализовать +армор +урон или еще что-то
        }
    }
}
