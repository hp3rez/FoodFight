using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Image healthBar; 
    public float maxHealth = 0.3f;
    public float currentHealth;

    void Start()
    {
        currentHealth = 0.3f;
        UpdateHealthUI(); 
    }

    void UpdateHealthUI()
    {
        healthBar.fillAmount = currentHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damageAmount;

            if(currentHealth < 0) {
                currentHealth = 0;
            }

            UpdateHealthUI();
        }
    }

    public void Heal(float healAmount)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += healAmount;
            if(currentHealth > maxHealth) {
                currentHealth = maxHealth;
            }
            UpdateHealthUI();
        }
    }
}
