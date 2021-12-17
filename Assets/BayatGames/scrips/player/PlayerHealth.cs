using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject player;
    public float shootInterval = 3f;
    float shootTime = 0;
    Enemy enemyinrange;

    public healthbar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (enemyinrange != null)
        {
            if (shootTime == 0)
            {
                TakeDamage(enemyinrange.Damage);
                shootTime = shootInterval;
            }

            shootTime -= Time.deltaTime;
        }
        else
        {
            shootTime = 0;
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

    private void OnCollisionEnter2D(Collision2D collision)
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

    private void OnCollisionExit2D(Collision2D collision)
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