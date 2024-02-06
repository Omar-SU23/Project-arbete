using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public PlayerController player;
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    private SpriteRenderer spriteRenderer;

    public int ammo = 1;
    public bool autoFire = true;
    public float shootingRate = 0.24f;
    private float shootingTimer = 0f;

    void Start()
    {

    }


    void Update()
    {
        if (Input.GetButtonDown("Fire"))
        {
            if (ammo >= 0)
            {
                float angle = Mathf.Atan2(player.lastDir.y, player.lastDir.x) * Mathf.Rad2Deg;

                GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.Euler(0f, 0f, angle));
                ammo--;
            }
        }
        float rotation = Input.GetAxis("mouse X" + "mouse Y");
        transform.Rotate(0f, 0f, rotation);

        
    }
    public void AddAmmo(int amount)
    {
        ammo += amount;
    }
}