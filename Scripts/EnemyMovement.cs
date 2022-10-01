using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    CharacterController controller;
    float heading;
    public float directionChangeInterval = 1f;
    public float maxHeadingChange = 30;
    Vector3 targetRotation;
    public float speed = 1f;

    void Awake()
    {
        controller = GetComponent<CharacterController>();

        heading = Random.Range(0, 360);

        transform.eulerAngles = new Vector3(0, heading, 0);

        StartCoroutine(NewHeading());
    }

    IEnumerator NewHeading()
    {
        while (true)
        {
            NewHeadingRoutine();

            yield return new WaitForSeconds(directionChangeInterval);
        }
    }

    void NewHeadingRoutine()
    {
        var floor = Mathf.Clamp(heading - maxHeadingChange, 0, 360);

        var ceiling = Mathf.Clamp(heading + maxHeadingChange, 0, 360);

        heading = Random.Range(floor, ceiling);

        targetRotation = new Vector3(0, heading, 0);
    }

    void Update()
    {
        transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation, Time.deltaTime * directionChangeInterval);

        var forward = transform.TransformDirection(Vector3.forward);

        controller.SimpleMove(forward * speed);

        if (this.transform.position.y < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
