using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    private Vector3 startPosition;

    public float power = 0.2f;
    public float duration = 0.2f;
    public float slowDownAmount = 1;
    private float initialDuration;
    private bool shouldShake;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.localPosition;
        initialDuration = duration;
    }

    // Update is called once per frame
    void Update()
    {
        Shake();
    }

    void Shake()
    {
        //if we should shake the camera
        if (shouldShake)
        {
            if (duration > 0)
            {
                transform.localPosition = startPosition + Random.insideUnitSphere * power;
                duration -= Time.deltaTime * slowDownAmount;
            }
            else
            {
                shouldShake = false;
                duration = initialDuration;
                transform.localPosition = startPosition;
            }
        }
    }

    public bool ShouldShake
    {
        get
        {
            return shouldShake;
        }
        set
        {
            shouldShake = value;
        }
    }
}
