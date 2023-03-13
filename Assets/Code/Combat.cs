using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

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
    public float nextAttackTime1 = 0f;
    public float nextAttackTime2 = 0f;

    public AudioSource attack;
    public AudioSource attack1;

    void Start()
    {
        attack = GameObject.Find("attack").GetComponent<AudioSource>();
        attack1 = GameObject.Find("attack1").GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= nextAttackTime0)
        {
            Attack0();
            nextAttackTime0 = Time.time + 0.5f / attackRate0;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) && Time.time >= nextAttackTime1)
        {
            Attack1();
            nextAttackTime1 = Time.time + 1f / attackRate1;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextAttackTime2)
        {
            Attack2();
            nextAttackTime2 = Time.time + 5f / attackRate2;
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
        attack.Play();
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

        attack1.Play();
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

