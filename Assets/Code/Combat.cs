using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public Animator anim;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public float attackRate0 = 1f;
    public float attackRate1 = 2f;
    public float attackRate2 = 3f;

    public float nextAttackTime0 = 0f;


    void Update()
    {  
        if (Time.time >= nextAttackTime0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack0();
                //nextAttackTime0 = Time.time + 1f / attackRate0;
            }
            else if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Attack1();
                //nextAttackTime0 = Time.time + 1f / attackRate1;

            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack2();
                //nextAttackTime0 = Time.time + 1f / attackRate2;

            }
        }
    }

    void Attack0()
    {
        anim.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(5);
        }
    }

    void Attack1()
    {
        anim.SetTrigger("Attack1");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(10);
        }
    }

    void Attack2()
    {
        anim.SetTrigger("Attack2");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(20);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}