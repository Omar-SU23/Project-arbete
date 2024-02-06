using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jonathan_move : MonoBehaviour
{
    private Rigidbody2D rb;
    //private SpriteRenderer spriteRenderer;
    private Animator animator;

    public float speed = 5f;
    private Vector2 moveDir;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        moveDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (moveDir.magnitude > 1f)
        {
            moveDir.Normalize();
        }

        // Set animation parameters
        if (moveDir.sqrMagnitude > 0.01f)
        {
            animator.SetFloat("xMove", moveDir.x);
            animator.SetFloat("yMove", moveDir.y);


            //flip player
            //spriteRenderer.flipX = moveDir.x > 0f ? true : false;
        }
        animator.SetBool("moving", moveDir.sqrMagnitude > 0.01f ? true : false);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDir * speed * Time.fixedDeltaTime);
    }

}
