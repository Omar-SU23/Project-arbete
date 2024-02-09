using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage;
    public Health playerhealth;
    public GameObject gameoverpanel;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerhealth.TakeDamage(damage);
        }
        if ((float)playerhealth.health <= 0)
        {
            gameoverpanel.SetActive(true);
        }
    }

}
