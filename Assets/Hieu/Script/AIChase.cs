using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    /*
    public GameObject player;
    public float speed;
    public float distanceBetween;
    private float distance;
    private Vector2 moveDir;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        moveDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (moveDir.magnitude > 1f)
            moveDir.Normalize();

        if (moveDir.sqrMagnitude > 0.01f)
        {
            animator.SetFloat("xMove", moveDir.x);
            animator.SetFloat("yMove", moveDir.y);
        }

        if (distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }*/
}
