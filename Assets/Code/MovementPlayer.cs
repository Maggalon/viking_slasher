using System.Runtime.CompilerServices;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    private float moveSpeed = 5f;


    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator anim;
    private SpriteRenderer sr;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Flex();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); 
        anim.SetFloat("Horizontal", Mathf.Abs(movement.x));
        anim.SetFloat("Vertical", Mathf.Abs(movement.y));
    }

    void Flex() // хуйня чтобы чел мог влево и вправо двигаться с анимкой
    {
        if (movement.x > 0)
        {
            sr.flipX = false;
        }
        else if (movement.x < 0)
        {
            sr.flipX = true;
        }
    }
}