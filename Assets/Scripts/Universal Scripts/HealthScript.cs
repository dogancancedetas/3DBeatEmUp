using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    private CharacterAnimation animationScript;
    private EnemyMovement enemyMovement;
    private HealthUI healthUI;

    public float health = 100;
    private bool characterDied;
    public bool isPlayer;

    private void Awake()
    {
        animationScript = GetComponentInChildren<CharacterAnimation>();

        if (isPlayer)
            healthUI = GetComponent<HealthUI>();
    }

    public void ApplyDamage(float damage, bool knockDown)
    {
        if (characterDied)
            return;

        health -= damage;

        //display health UI
        if (isPlayer)
            healthUI.DisplayHealth(health);

        if (health <= 0)
        {
            animationScript.Death();
            characterDied = true;

            //if is the player deactivate enemy script
            if (isPlayer)
                GameObject.FindWithTag(Tags.ENEMY_TAG).GetComponent<EnemyMovement>().enabled = false;

            return;
        }

        if (!isPlayer)
        {
            if (knockDown)
            {
                if (Random.Range(0, 2) > 0)
                    animationScript.KnockDown();
            }
            else
            {
                if (Random.Range(0, 3) > 1)
                    animationScript.Hit();
            }
        }
    }
}
