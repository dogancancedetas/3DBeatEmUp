using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{

    private CharacterAnimation animationScript;
    private EnemyMovement enemyMovement;

    public float health = 100;
    private bool characterDied;
    public bool isPlayer;

    private void Awake()
    {
        animationScript = GetComponentInChildren<CharacterAnimation>();
    }

    public void ApplyDamage(float damage, bool knockDown)
    {
        if (characterDied)
            return;

        health -= damage;

        //display health UI
        if (health <= 0)
        {
            animationScript.Death();
            characterDied = true;

            //if is the player deactivate enemy script
            if (isPlayer)
            {

            }
            return;
        }

        if (!isPlayer)
        {
            if (knockDown)
            {
                if (Random.Range(0, 2) > 0)
                {
                    animationScript.KnockDown();
                }
            }
            else
            {
                if (Random.Range(0, 3) > 1)
                {
                    animationScript.Hit();
                }
            }
        }
    }
}
