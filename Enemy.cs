using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public int maxHealth = 100;
    int currentHealth;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        

        // Animation
        animator.SetTrigger("Damaged");

        if (GameObject.Find("Player").GetComponent< PlayerMovement> ().facingRight == true) {
            rb.AddForce(Vector2.right * 600, ForceMode2D.Impulse);
            rb.AddForce(Vector2.up * 100, ForceMode2D.Impulse);
        }
        else {
            rb.AddForce(Vector2.left * 1200, ForceMode2D.Impulse);
            rb.AddForce(Vector2.up * 10000, ForceMode2D.Force);
        }

        if (currentHealth < 0) {
            rb.freezeRotation = false;
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
        }
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player") {
            target.GetComponent<PlayerHealth>().TakeDamage(20);
        }
    }
}

