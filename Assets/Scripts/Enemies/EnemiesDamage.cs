using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class EnemiesDamage : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    private ScoreScript s;

    private void Awake() {
        s = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<ScoreScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player") {
            collision.GetComponent<Health>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    private void Update() {
        transform.position = transform.position + (Vector3.left * speed) * Time.deltaTime;

        if(transform.position.x <= -1.75) {
            Destroy(gameObject);
            s.addScore(1);
        }
    }
}
