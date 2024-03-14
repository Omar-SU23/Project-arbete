using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;


public class Shooting : MonoBehaviour
{
    public PlayerController player;
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    private SpriteRenderer spriteRenderer;
    private Transform mTransform;
    private Vector3 rotation;
    public AudioClip ShootSound;
    public AudioClip reloadSound;
    public AudioClip clickSound;
    private AudioSource audioSource;

    public float angle;
    public int maxAmmo = 6;
    public int currentAmmo = 6;
    public float reload = 2f;
    private bool isReloading = false;
    public float shootingRate = 0.24f;
    private float shootingTimer = 0f;
    private bool isFire = false;

    
    private void Start()
    {
        mTransform = this.transform;
        audioSource = GetComponent<AudioSource>();
        currentAmmo = maxAmmo;
    }

    private void LAMouse()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - mTransform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        mTransform.rotation = rotation;

    }

    
    void Update()
    {
        if (Input.GetButtonDown("Fire"))
        {
            
            if (currentAmmo > 0 && isFire == false)
            {
                float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

                GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
                currentAmmo--;
                audioSource.PlayOneShot(ShootSound);

                isFire = true;

                StartCoroutine(FireRate());
            }
            else
            {
                audioSource.PlayOneShot(clickSound);
            }
        }
        LAMouse();

        if(currentAmmo <=0 && isReloading == false)
        {
            
            StartCoroutine(Reload());
            return;
        }

       
    }
   
    IEnumerator Reload()
    {
        isReloading = true;
        //Debug.Log("Reloading...");

        yield return new WaitForSeconds(reload);

        currentAmmo = maxAmmo;

        isReloading = false;
    }

    IEnumerator FireRate()
    {
        yield return new WaitForSeconds(shootingRate);
        isFire = false;
    }
}