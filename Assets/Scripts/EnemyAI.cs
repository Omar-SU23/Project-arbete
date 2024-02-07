using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    public float checkRadius;
    

    public bool shouldRotate;

    public LayerMask whatIsPlayer;

    private Transform target;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;
    public Vector3 dir;

    private bool isInChaseRange;
    private bool isInAttackRange;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;

    }

    
    void Update()
    {
        animator.SetBool("moving", isInChaseRange);
        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
        

        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;
        if(shouldRotate)
        {
            animator.SetFloat("xMove", dir.x);
            animator.SetFloat("yMove", dir.y);
        }
    }

    private void FixedUpdate()
    {
       if(isInChaseRange && !isInAttackRange)
        {
            MoveCharacter(movement);
        }
       if(isInAttackRange)
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void MoveCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    }
}
