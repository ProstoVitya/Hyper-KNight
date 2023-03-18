using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private float MaxHealth = 100f;
    private float _currentHealth;

    private void Awake()
    {
        _currentHealth = MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0) Destroy(this.gameObject);
        Debug.Log($"current HP: {_currentHealth}");
    }

    public void Heal(float healingHp)
    {
        _currentHealth += healingHp;
        if (_currentHealth > MaxHealth) _currentHealth = MaxHealth;
        Debug.Log($"current HP: {_currentHealth}");
    }
}
