using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool IsEndBoss = false;
    public int Damage = 20;
    public string NextLevel = "";
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        if (IsEndBoss)
        {
            // this is where the game ends
            SceneManager.LoadScene(NextLevel);
        }
    }
    

}