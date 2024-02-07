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
    private Vector3 rotation;

    public float angle;
    public int maxAmmo = 6;
    private int currentAmmo;
    public float reload = 2f;
    private bool isReloading = false;
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
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        mTransform.rotation = rotation;

    }
    
    void start()
    {
        currentAmmo = maxAmmo;
    }
    
    void Update()
    {
        if (Input.GetButtonDown("Fire"))
        {
            
            if (currentAmmo > 0)
            {
                float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

                GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
                currentAmmo--;
            }
        }
        LAMouse();

        if(currentAmmo <=0)
        {
            StartCoroutine(Reload());
            return;
        }

       IEnumerator Reload()
        {
            isReloading = true;

            Debug.Log("Reloading...");

            yield return new WaitForSeconds(reload);

            currentAmmo = maxAmmo;

            isReloading = false;
        }
    }
}