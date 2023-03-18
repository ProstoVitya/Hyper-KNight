using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Fireball : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifetime;
    [SerializeField] private float _damage;

    private Rigidbody _myRigidBody;
    private SphereCollider _myColider;

    private void Awake()
    {
        _myColider = GetComponent<SphereCollider>();
        _myColider.isTrigger = true;

        _myRigidBody = GetComponent<Rigidbody>();
        _myRigidBody.isKinematic = true;

        Destroy(this.gameObject, _lifetime);

    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            HealthComponent enemyHealth = other.GetComponent<HealthComponent>();
            enemyHealth.TakeDamage(_damage); 
        }
        Destroy(this.gameObject);
    }
}