using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    [SerializeField] private float healAmount;
    [SerializeField] private float speed;
    

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            collision.GetComponent<Health>().Heal(healAmount);
            Destroy(gameObject);
        }
    }

    private void Update() {
        transform.position = transform.position + (Vector3.left * speed) * Time.deltaTime;

        if(transform.position.x <= -1.75) {
            Destroy(gameObject);
        }
    }
}
