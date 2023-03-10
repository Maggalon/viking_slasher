using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Animator anim;
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        } 
    }

    void Attack()
    {
        anim.SetTrigger("Attack");
    }
}
