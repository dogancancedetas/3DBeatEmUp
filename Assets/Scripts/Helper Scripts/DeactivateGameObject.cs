using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateGameObject : MonoBehaviour
{
    public float timer = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DeactivateAfterTime", timer);
    }

    void DeactivateAfterTime()
    {
        Destroy(gameObject);
    }
}
