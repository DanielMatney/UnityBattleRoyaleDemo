using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{

    private Vector3 ScaleChange;
    private float MinimumGroundSize = 1f;

    void Start()
    {
        float ScaleByAmount = 0.002f;

        ScaleChange = new Vector3(ScaleByAmount, 0, ScaleByAmount);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.localScale.x <= MinimumGroundSize)
        {
            return;
        }

        this.transform.localScale -= ScaleChange;
    }
}
