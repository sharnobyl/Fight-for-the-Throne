using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public float attackRange = 0.5f;
    public int attackDamage = 35;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    void Update()
    {
        if (Time.time >= nextAttackTime) {
            if (Input.GetKeyDown(KeyCode.J)) {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
    void Attack()
    {
        // Animation
        animator.SetTrigger("Attack");

        // Enemy Detection
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damage
        foreach(Collider2D enemy in hitEnemies) {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);       
              
        }
   
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
