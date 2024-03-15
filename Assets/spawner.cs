using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject spawnobj;
    public int maxCount = 0;
    public float spawnerinterval = 3f;
    private int spawnCount = 0;
    void Start()
    {
        spawn();
        if (maxCount >= 1)
            InvokeRepeating("spawn", spawnerinterval, spawnerinterval);
    }

    // Update is called once per frame
    void spawn()
    {

        spawnCount++;
        if (spawnCount >= maxCount)
            CancelInvoke();
        Instantiate(spawnobj, transform.position, Quaternion.identity);


    }
}
