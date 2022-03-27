using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [HideInInspector] public bool isFiring;

    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 15f;
    [SerializeField] float baseFireRate = 0.2f;   // how many projectiles you want to shoot per second
    [SerializeField] float projectileLifetime = 5f;

    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float fireRateVariance = 0;
    [SerializeField] float minFireRate = 1f;

    Coroutine firingCoroutine;
    
    void Start()
    {
        if (useAI)
            isFiring = true;
    }

    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (isFiring && firingCoroutine == null)
            firingCoroutine = StartCoroutine(FireContinuously());
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    private IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.velocity = transform.up * projectileSpeed;
            Destroy(instance, projectileLifetime);
            
            float timeToNextProjectile = Random.Range(baseFireRate - fireRateVariance, baseFireRate + fireRateVariance);
            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minFireRate, float.MaxValue);
            yield return new WaitForSeconds(timeToNextProjectile);
        }
    }
}
