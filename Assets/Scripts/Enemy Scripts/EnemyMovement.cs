using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private CharacterAnimation enemyAnim;
    private Rigidbody myBody;
    private Transform playerTarget;

    public float speed = 5;
    public float attackDistance, chasePlayerAfterAttack = 1;
    private float currentAttackTime;
    private float defaultAttackTime =2;
    private bool followPlayer, attackPlayer;
    
    void Awake()
    {
        enemyAnim = GetComponentInChildren<CharacterAnimation>();
        myBody = GetComponent<Rigidbody>();

        playerTarget = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        followPlayer = true;
        currentAttackTime = defaultAttackTime;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void FixedUpdate()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        //if we are not supposed to follow the player
        if (!followPlayer)
            return;

        if (Vector3.Distance(transform.position, playerTarget.position) > attackDistance)
        {
            transform.LookAt(playerTarget);
            myBody.velocity = transform.forward * speed;

            if (myBody.velocity.sqrMagnitude != 0)
            {
                enemyAnim.Walk(true);
            }
        }
        else if (Vector3.Distance(transform.position, playerTarget.position) <= attackDistance)
        {
            myBody.velocity = Vector3.zero;
            enemyAnim.Walk(false);

            followPlayer = false;
            attackPlayer = true;
        }
    }

    void Attack()
    {
        //if we are not supposed to attack the player
        if (!attackPlayer)
        {
            return;
        }

        currentAttackTime += Time.deltaTime;

        if (currentAttackTime > defaultAttackTime)
        {
            enemyAnim.EnemyAttack(Random.Range(0, 3));
            currentAttackTime = 0;
        }

        if (Vector3.Distance(transform.position, playerTarget.position) > attackDistance + chasePlayerAfterAttack)
        {
            attackPlayer = false;
            followPlayer = true;
        }
    }
}
