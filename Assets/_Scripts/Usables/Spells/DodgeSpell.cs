using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Usables.Spells
{
    public class DodgeSpell : SimpleSpell
    {
        [SerializeField] private GameObject _particles;

        private float _armorBoost = 100f;

        protected override void UseSpell(Transform transform)
        {
            GameObject spawnedObject = Instantiate(_particles, transform.position, transform.rotation);
            Destroy(spawnedObject, 0.5f);
            Debug.Log("dodge");
        }
    }

}