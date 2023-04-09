using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Usables.Spells
{
    public class AoeSpell : SimpleSpell
    {
        [SerializeField] private float _damage;
        [SerializeField] private GameObject _particles;
        private float _radius = 5f;

        protected override void UseSpell(Transform transform)
        {
            GameObject spawnedObject = Instantiate(_particles, transform.position, transform.rotation);
            Destroy(spawnedObject, 0.5f);
            Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Enemy"))
                {
                    HealthComponent enemyHealth = collider.GetComponent<HealthComponent>();
                    enemyHealth.TakeDamage(_damage);
                }
            }
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _radius);
        }
    }
}