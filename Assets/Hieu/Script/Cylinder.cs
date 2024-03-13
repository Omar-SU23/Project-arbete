using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cylinder : MonoBehaviour
{
    public Image[] ammo;
    public Shooting shootingScript;
    private int nrOfAmmo;

    void Start()
    {
        nrOfAmmo = ammo.Length;
    }

    void Update()
    {
        float frame = (float)shootingScript.currentAmmo / (float)shootingScript.maxAmmo;
        DisplayAmmo(Mathf.RoundToInt(frame * nrOfAmmo));
    }

    void DisplayAmmo(int count)
    {
        for (int i = 0; i < ammo.Length; i++)
        {
            ammo[i].enabled = i < count ? true : false;
        }
    }
}
