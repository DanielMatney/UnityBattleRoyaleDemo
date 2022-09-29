using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject theEnemy;

    public int enemiesCreated;

    void Start()
    {
        StartCoroutine(CreateEnemies());
    }

    IEnumerator CreateEnemies()
    {
        int numberOfEnemies = 10;
        float yPosition = 0.5f;

        while (enemiesCreated < numberOfEnemies)
        {
            var xPosition = Random.Range(-15, 15);
            var zPosition = Random.Range(-15, 15);

            Instantiate(theEnemy, new Vector3(xPosition, yPosition, zPosition), Quaternion.identity);

            yield return new WaitForSeconds(0.1f);

            enemiesCreated++;
        }
    }

    void Update()
    {
        
    }
}
