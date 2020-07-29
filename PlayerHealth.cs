using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -10) {
            Die();
        }
        if (currentHealth < 0) {
            Die();
        }
        if (Input.GetKeyDown(KeyCode.Y)) {
            TakeDamage(20);
        }
    }
    void Die()
    { 
        SceneManager.LoadScene("SampleScene");
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
