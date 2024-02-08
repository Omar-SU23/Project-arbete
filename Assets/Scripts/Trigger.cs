using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public string collidingTag;
    public bool destroy = true;
    public bool oneHit = true;
    public GameObject spawnObject;
    public UnityEvent triggerEnter;

    void Start()
    {
        if (triggerEnter == null)
            triggerEnter = new UnityEvent();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(collidingTag))
        {
            triggerEnter.Invoke();

            if (spawnObject != null)
                Instantiate(spawnObject, transform.position, Quaternion.identity);

            if (destroy)
                Destroy(gameObject);

            if (oneHit)
                Destroy(this);



        }
    }

}