﻿using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]

public class Healthenemy : MonoBehaviour
{
    public int health = 5;
    public int maxHealth = 5;
    [HideInInspector] public bool isDead = false;
    public GameObject deathEffect;
    public GameObject hitParticles;
    public AudioClip hurtSound;
    public AudioClip deathSound;
    public UnityEvent onTakeDamage;
    public UnityEvent onDeath;
    private AudioSource audioSource;
    private Animator animator;
    private NavMeshAgent nav;
    public bool destroyOnDead = false;


    void Awake()
    {
        // Get component references
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        nav = GetComponentInParent<NavMeshAgent>();

        if (onTakeDamage == null)
            onTakeDamage = new UnityEvent();
        if (onDeath == null)
            onDeath = new UnityEvent();
    }

    public void TakeDamage(int amount)
    {
        // Don't do anything if dead
        if (isDead)
            return;

        // Reduce health by amount of damage
        health -= amount;

        // Is dead?
        if (health <= 0)
        {
            isDead = true;

            // Instatiate death particles
            if (deathEffect != null)
                Instantiate(deathEffect, transform.position, transform.rotation);

            // Play death animation
            if (animator != null)
                animator.SetTrigger("dead");

            // Play death sound
            if (deathSound != null)
                audioSource.PlayOneShot(deathSound);

            // stop updating navmesh for objects with pathfinding
            if (nav != null)
                nav.isStopped = true;

            onDeath.Invoke();

            if (destroyOnDead == true)
            {
                Destroy(gameObject);
            }
        }
        // Got hit
        else
        {
            // Play hurt sound effect
            if (hurtSound != null)
                audioSource.PlayOneShot(hurtSound);

            // Play hit animation
            if (animator != null)
                animator.SetTrigger("hit");

            Instantiate(hitParticles, transform.position, Quaternion.identity);

            onTakeDamage.Invoke();
        }
    }

    // Call this on pick up event
    public void AddHealth(int amount)
    {
        //health = (int)Mathf.Clamp(health += hp, 0, maxHealth);

        health += amount;


    }

    // Call this on last frame of death animation
    public void DestroyObject()
    {
        Destroy(gameObject);
    }

}
