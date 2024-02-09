   using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    
    private SpriteRenderer spriteRenderer;

    public float speed = 5f;
    private Vector2 moveDir;
    [HideInInspector] public Vector2 lastDir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        lastDir = Vector2.down;
    }


    void Update()
    {
        moveDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (moveDir.magnitude > 1f)
            moveDir.Normalize();

        
    }


            private void FixedUpdate()
    {
        // Move player
        rb.MovePosition(rb.position + moveDir * speed * Time.fixedDeltaTime);
    }
}
