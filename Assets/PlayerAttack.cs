using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator ani;
    private PlayerScript ps;

    [SerializeField] private float attackCooldown;
    private float cooldownTimer = Mathf.Infinity;
    [SerializeField] private Transform projectilePoint;
    [SerializeField] private GameObject[] projectiles; 

    private void Awake() {
        ani = GetComponent<Animator>();
        ps = GetComponent<PlayerScript>();
    }

    private void Update() {
        if(Input.GetKey(KeyCode.Space) && cooldownTimer > attackCooldown && ps.canAttack()) {
            Attack();
        }

        cooldownTimer += Time.deltaTime;
    }

    private void Attack() {
        //ani.SetTrigger("attack");
        cooldownTimer = 0;

        projectiles[0].transform.position = projectilePoint.position;
        projectiles[0].GetComponent<ProjectileScript>().SetDirection(Mathf.Sign(transform.localScale.x)); 
    }
}