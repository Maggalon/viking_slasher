using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 0;
    public Animator animator;
    
    public AudioSource dead;

    void Start()
    {
        currentHealth = maxHealth;
        dead = GameObject.Find("dead").GetComponent<AudioSource>();

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0) 
        {
            Die();
        }
    }
     
    void Die()
    {
        animator.SetBool("isDead",true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        dead.Play();


    }


}
