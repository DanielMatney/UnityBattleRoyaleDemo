using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    bool attacking = false;

    public ParticleSystem bulletParticleSystem;

    private ParticleSystem.EmissionModule em;

    float attackTimer = 0f;

    void Start()
    {
        em = bulletParticleSystem.emission;
    }

    private float FiringRate = 10f;

    void Update()
    {
        attacking = Input.GetMouseButton(0);

        attackTimer += Time.deltaTime;

        if(attacking && attackTimer >= 1f/FiringRate)
        {
            attackTimer = 0;
            Attack();
        }

        em.rateOverTime = attacking ? FiringRate : 0f;

    }

    void Attack()
    {
        Ray ray = new Ray(bulletParticleSystem.transform.position, bulletParticleSystem.transform.forward);

        float raycastLength = 100f;

        if (Physics.Raycast(ray, out RaycastHit hit, raycastLength))
        {
            var playerHitHealthScript = hit.collider.GetComponent<PlayerHealth>();

            if (playerHitHealthScript != null)
            {
                float reduceHealthBy = 10f;
                playerHitHealthScript.ReduceHealth(reduceHealthBy);
            }
        }
        //check for collision
        //reduce health
    }
}
