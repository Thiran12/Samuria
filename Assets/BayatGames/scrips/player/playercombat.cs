using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackrange = 0.6f;
    public int attackDamage = 50;
    public LayerMask enemyLayers;
    SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }
    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackrange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {

            //flipX == true means facing left
            //flipX == false means facing right
            
            if (sprite.flipX && enemy.transform.position.x<transform.position.x)
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            }
            else if (!sprite.flipX && enemy.transform.position.x > transform.position.x)
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackrange);

    }
}