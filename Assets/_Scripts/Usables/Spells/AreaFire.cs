using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaFire : MonoBehaviour
{
    [SerializeField] private float _lifetime;
    [SerializeField] private float _damage;
    [SerializeField] private float _cooldownAttack;
    private float _radius=3f;
    private float _timeToAttack = 0f;
    private void Awake()
    {
        Destroy(this.gameObject, _lifetime);

    }
    
    private void FixedUpdate()
    {
        _timeToAttack += Time.fixedDeltaTime;
        if (_timeToAttack >= _cooldownAttack)
        {
            //layermask можно использовать
            Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Enemy"))
                {
                    HealthComponent enemyHealth = collider.GetComponent<HealthComponent>();
                    enemyHealth.TakeDamage(_damage);
                }
            }
            _timeToAttack = 0f;
        }
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
