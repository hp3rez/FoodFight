using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSideways : MonoBehaviour
{
    
    [SerializeField] private float moveDist;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private float leftEdge;
    private float rightEdge;
    private bool movingLeft;

    private void Awake() {
        leftEdge = transform.position.x - moveDist;
        rightEdge = transform.position.x + moveDist;
    }

    private void Update() {
        if(movingLeft) {
            if(transform.position.x > leftEdge) {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            } else {
                movingLeft = false;
            }
        } else{
            if(transform.position.x < rightEdge) {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            } else {
                movingLeft = true;
            }
        }

        transform.position = transform.position + (Vector3.left * speed) * Time.deltaTime;

        if(transform.position.x <= -1.75) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
