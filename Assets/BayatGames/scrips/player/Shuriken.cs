using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Shuriken : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 30;
    public Rigidbody2D rb;
    public bool Enemyarrow = false;
    void Start()
    {
        rb.velocity = transform.forward * speed;
    }
    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
        

        PlayerHealth Player = hitInfo.GetComponent<PlayerHealth>();
        if (Player != null && Enemyarrow)
        {
            Player.TakeDamage(damage);
            Destroy(gameObject);
        }

        if (hitInfo.GetType() == typeof(TilemapCollider2D))
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame

}