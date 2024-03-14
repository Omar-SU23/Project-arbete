using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;
    public float speed = 10f;
    public float knockback = 1f;
    public float lifeTime = 5f;

    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * speed, ForceMode2D.Impulse);
        Destroy(gameObject, lifeTime);
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            return;

        if (collision.CompareTag("Enemy"))
        {
            Healthenemy health = collision.gameObject.GetComponent<Healthenemy>();

            health.TakeDamage(damage);  
        }
        Destroy(gameObject);
    }

}
