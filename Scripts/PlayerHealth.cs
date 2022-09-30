using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;

    public void ReduceHealth(float damage)
    {
        health -= damage;
    }
}
