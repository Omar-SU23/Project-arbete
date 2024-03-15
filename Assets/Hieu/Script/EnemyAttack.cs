using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage;
    //public Health playerhealth;
    public GameObject gameoverpanel;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            var hp = collision.gameObject.GetComponent<Health>();
            hp.TakeDamage(damage);
        }
    
    }


    public void FindPlayer()
    {
        gameoverpanel = GameObject.Find("gameOver");
        
    }
}
