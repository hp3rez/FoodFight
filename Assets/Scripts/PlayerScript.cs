using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    private float hInput;
    private float wallJumpCooldown;
    private Rigidbody2D body;
    private BoxCollider2D box;
    private Animator ani;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    //initializes body and ani variables
    private void Awake() {
        body = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }

    // Deals with left to right movement and jumping
    private void Update()
    {
        //moves the player left and right
        hInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(hInput * speed, body.velocity.y);

        //flips the sprite when moving left and right
        if(hInput > 0.01f) {
            transform.localScale = Vector3.one;
        } else if (hInput < -0.01f) {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //allows walljumps
        if(wallJumpCooldown > 0.2f) {
            body.velocity = new Vector2(hInput * speed, body.velocity.y);

            if(onWall() && !isGrounded()) {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            } else {
                body.gravityScale = 3;
            }

            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
                Jump();
            }
        } else {
            wallJumpCooldown += Time.deltaTime;
        }

        //set animator parameters based on whether player is moving
        //ani.SetBool("run", hInput != 0);
        //ani.SetBool("grounded", isGrounded());
    }

    //controls the jumping movement and animation
    private void Jump() {
        if(isGrounded()) {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            //ani.SetTrigger("jump");
        } else if(onWall() && !isGrounded()) {
            wallJumpCooldown = 0;
           
            if(hInput == 0) {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            } else {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 3);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        
    }

    //determines whether player is on ground
    private bool isGrounded() {
        RaycastHit2D hit = Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return hit.collider != null;
    }

    //determines whether player is on a wall
    private bool onWall() {
        RaycastHit2D hit = Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return hit.collider != null;
    }

    public bool canAttack() {
        return isGrounded() && !onWall();
    }

}
