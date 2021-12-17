using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject player;
    float shootInterval = 3f;
    float shootTime;
    Enemy enemyinrange;

    public healthbar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }

    private void OnUpdate()
    {
        shootTime += Time.deltaTime;
        if (enemyinrange != null && shootTime > shootInterval)
        {
            shootTime = 0f;
            TakeDamage(enemyinrange.Damage);

        }

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnCollisonEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            var enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemyinrange = enemy;
            }
           
        }
        if (collision.gameObject.CompareTag("void"))
        {

            TakeDamage(100);
        }
    }

    private void OnCollisonExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            var enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemyinrange = null;
            }

        }
    }
}   

      