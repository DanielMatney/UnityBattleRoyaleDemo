using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;

    public void ReduceHealth(float damage)
    {
        health -= damage;

        if (health < 1)
        {
            if (this.gameObject.tag == "Enemy")
            {
                Destroy(this.gameObject);
            }

            else if (this.gameObject.tag == "Player")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
