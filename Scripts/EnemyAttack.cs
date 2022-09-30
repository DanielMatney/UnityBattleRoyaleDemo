using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public ParticleSystem bulletParticleSystem;
    private ParticleSystem.EmissionModule em;

    void Start()
    {
        em = bulletParticleSystem.emission;
    }

    private float RaycastLength = 100f;

    private float FiringRate = 5f;
    float attackTimer = 0f;

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        
        if (Physics.Raycast(transform.position, forward, RaycastLength))
        {
            attackTimer += Time.deltaTime;

            if(attackTimer >= 1f/FiringRate)
            {
                Attack();
                attackTimer = 0f;
            }

            em.rateOverTime = FiringRate;
        }

        else
        {
            em.rateOverTime = 0f;
        }
    }

    void Attack()
    {
        Ray ray = new Ray(bulletParticleSystem.transform.position, bulletParticleSystem.transform.forward);
        float rayLength = 100f;
        float damage = 10f;

        if (Physics.Raycast(ray, out RaycastHit hit, rayLength))
        {
            var objectHit = hit.collider.GetComponent<PlayerHealth>();

            if (objectHit != null)
            {
                objectHit.ReduceHealth(damage);
            }
        }
    }
}
