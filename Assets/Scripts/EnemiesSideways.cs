using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSideways : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            Health playerHealth = collision.GetComponent<Health>();
            playerHealth.TakeDamage(0.1f);
        }
    }
}
