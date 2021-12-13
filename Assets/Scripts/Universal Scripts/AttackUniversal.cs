using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUniversal : MonoBehaviour
{
    public LayerMask collisionLayer;
    public float radius = 1;
    public float damage = 2;

    public bool isPlayer, isEnemy;

    public GameObject hitFXPrefab;

    // Update is called once per frame
    void Update()
    {
        DetectCollision();
    }

    void DetectCollision()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisionLayer);

        //if we have a hit
        if (hit.Length > 0)
        {
            //if is player
            if (isPlayer)
            {
                Vector3 hitFXPos = hit[0].transform.position;
                hitFXPos.y += 1.3f;

                if (hit[0].transform.forward.x > 0)
                {
                    hitFXPos.x += 0.3f;
                }
                else if (hit[0].transform.forward.x < 0)
                {
                    hitFXPos.x -= 0.3f;
                }

                Instantiate(hitFXPrefab, hitFXPos, Quaternion.identity);

                if (gameObject.CompareTag(Tags.LEFT_ARM_TAG) || gameObject.CompareTag(Tags.LEFT_LEG_TAG))
                {
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage, true);
                }
                else
                {
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage, false);
                }
            }
            gameObject.SetActive(false);
        }
    }
}
