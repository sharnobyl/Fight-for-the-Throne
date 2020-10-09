using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    public int maxHealth = 100;
    int currentHealth;
    private GameObject target;
    public float raycastMaxDistance = 0.4f;
    public float rayOffset = 0.9f;
    public int damageDealt = 1;
    public int knockBack = 2000;
    public float movementHor = 10000f;
    public float movementVer = 10000000000000000000f;

    public int scoreValue = 100;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("Move", 0, 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        
        RayCastDamage();
        if(rb.velocity.x > 10) {
            rb.velocity = new Vector2(3, rb.velocity.y);
        }
        else if(rb.velocity.x < -10) {
            rb.velocity = new Vector2(-3, rb.velocity.y);
        }
        if (gameObject.transform.position.y < -100) {
            gameObject.transform.position = new Vector2(Random.Range(9,10), 20);
            rb.velocity = new Vector2(1, 1);
            currentHealth -= 30;
        }
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
            //target.GetComponent<PlayerCombat>().playerScore += scoreValue;
            PlayerCombat.playerScore += scoreValue;
            Destroy(gameObject, 1);
            if(Random.Range(0, 5) == 1) {
                target.GetComponent<PlayerHealth>().TakeDamage(-50);
            }
        }
        
            
        
        
    }
   
    void RayCastDamage()
    {
        RaycastHit2D hitright = Physics2D.Raycast(new Vector2(transform.position.x + rayOffset, transform.position.y), new Vector2(1, 0), raycastMaxDistance);
        RaycastHit2D hitleft = Physics2D.Raycast(new Vector2(transform.position.x - rayOffset, transform.position.y), new Vector2(-1, 0), raycastMaxDistance);

        if (hitright.collider && hitright.collider.tag == "Player") {
            Debug.Log("Hit the collidable object right" + hitright.collider.name);
            target.GetComponent<PlayerHealth>().TakeDamage(damageDealt);
            target.GetComponent<PlayerCombat>().DamageAnim();

            target.GetComponent<Rigidbody2D>().AddForce(Vector2.right * knockBack, ForceMode2D.Force);
            target.GetComponent<Rigidbody2D>().AddForce(Vector2.up * knockBack * 0.25f, ForceMode2D.Force);

        }
        else if (hitleft.collider && hitleft.collider.tag == "Player") {
            Debug.Log("Hit the collidable object left " + hitleft.collider.name);
            target.GetComponent<PlayerHealth>().TakeDamage(damageDealt);
            target.GetComponent<PlayerCombat>().DamageAnim();
        
            target.GetComponent<Rigidbody2D>().AddForce(Vector2.left * knockBack, ForceMode2D.Force);
            target.GetComponent<Rigidbody2D>().AddForce(Vector2.up * knockBack * 0.25f, ForceMode2D.Force);
        }
    }
    void Move()
    {
        if(Mathf.Abs(target.transform.position.x - gameObject.transform.position.x) < 20){
            if(target.transform.position.x > gameObject.transform.position.x) { // Player is to the right
                rb.AddForce(Vector2.up * movementVer, ForceMode2D.Impulse);
                rb.AddForce(Vector2.up * movementVer, ForceMode2D.Impulse);
                rb.AddForce(Vector2.right * movementHor, ForceMode2D.Impulse);
            }
            else {                                                              // Player is to the left
                rb.AddForce(Vector2.up * movementVer, ForceMode2D.Impulse);
                rb.AddForce(Vector2.up * movementVer, ForceMode2D.Impulse);
                rb.AddForce(Vector2.left * movementHor, ForceMode2D.Impulse);
            }
        }
    }
}

