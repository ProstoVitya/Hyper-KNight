using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public HealthComponent playerHealth;

    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<HealthComponent>();
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = playerHealth.get_currentHealth();
        healthBar.value = healthBar.maxValue;
    }

    public void SetHealth(int hp)
    {
        //healthBar.value = hp;
    }

    void Update()
    {
        healthBar.value = playerHealth.get_currentHealth();
    }
}