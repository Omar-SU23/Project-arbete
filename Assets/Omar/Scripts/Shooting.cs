using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public PlayerController player;
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    private SpriteRenderer spriteRenderer;
    private Transform mTransform;

    public float angle;
    public int ammo = 1;
    public bool autoFire = true;
    public float shootingRate = 0.24f;
    private float shootingTimer = 0f;

    private void Start()
    {
        mTransform = this.transform;
    }

    private void LAMouse()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - mTransform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 0, Vector3.forward);
        mTransform.rotation = rotation;

    }
    void Update()
    {
        if (Input.GetButtonDown("Fire"))
        {
            
            if (ammo >= 0)
            {                
                GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.Euler(0f, 0f, angle));
                ammo--;
            }
        }
        LAMouse();

    }
    public void AddAmmo(int amount)
    {
        ammo += amount;
    }
}