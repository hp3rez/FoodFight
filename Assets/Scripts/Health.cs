using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private Image healthBar; 
    public float maxHealth = 0.3f;
    public float currentHealth;

    [Header("IFrames")]
    [SerializeField] private float iFrameDuration;
    [SerializeField] private int numFlashes;
    private SpriteRenderer sprite;

    void Start()
    {
        currentHealth = 0.3f;
        UpdateHealthUI(); 
        sprite = GetComponent<SpriteRenderer>();
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
            StartCoroutine(Invulnerability());
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

    private IEnumerator Invulnerability() {
        Physics2D.IgnoreLayerCollision(10, 11, true);

        for (int i = 0; i < numFlashes; i++) {
            sprite.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFrameDuration / (numFlashes * 2));
            sprite.color = Color.white;
            yield return new WaitForSeconds(iFrameDuration / (numFlashes) * 2);
        }

        Physics2D.IgnoreLayerCollision(10, 11, false);
    }
}
