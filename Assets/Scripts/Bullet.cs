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
    public float enemyhealth;
    public GameObject enemy;

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

        Health health = collision.gameObject.GetComponent<Health>();

        if (collision.CompareTag("Enemy"))
        {
            enemyhealth--;
            if(enemyhealth <= 0)
            {
                Destroy(enemy);
            }
            Destroy(gameObject);
        }
        
    }

}
