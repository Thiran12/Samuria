using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercombat : MonoBehaviour
{
    public Animator animator;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Attack();
        }
    }
    void Attack()
    {
        animator.SetTrigger("Attack");
    }
}