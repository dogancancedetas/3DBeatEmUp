using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComboState
{
    NONE,
    PUNCH_1,
    PUNCH_2,
    PUNCH_3,
    KICK_1,
    KICK_2
}

public class PlayerAttack : MonoBehaviour
{
    private CharacterAnimation playerAnim;
    private ComboState currentComboState;

    private bool activateTimerToReset;
    private float defaultComboTimer = 0.4f;
    private float currentComboTimer;

    void Awake()
    {
        playerAnim = GetComponentInChildren<CharacterAnimation>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        currentComboTimer = defaultComboTimer;
        currentComboState = ComboState.NONE;
    }

    // Update is called once per frame
    void Update()
    {
        ComboAttacks();
        ResetComboState();
    }

    void ComboAttacks()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (currentComboState == ComboState.PUNCH_3 || currentComboState == ComboState.KICK_1 || currentComboState == ComboState.KICK_2)
                return;

            currentComboState++;
            activateTimerToReset = true;
            currentComboTimer = defaultComboTimer;

            if (currentComboState == ComboState.PUNCH_1)
                playerAnim.Punch_1();

            if (currentComboState == ComboState.PUNCH_2)
                playerAnim.Punch_2();

            if (currentComboState == ComboState.PUNCH_3)
                playerAnim.Punch_3();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            //current combo is punch 3 or kick 2
            //exit because we have no combos to perform
            if (currentComboState == ComboState.KICK_2 || currentComboState == ComboState.PUNCH_3)
                return;

            //if the current combo state is None, or punch1 or punch2 then we can set current combo state to kick1 to chain the combo
            if (currentComboState == ComboState.NONE || currentComboState == ComboState.PUNCH_1 || currentComboState == ComboState.PUNCH_2)
                currentComboState = ComboState.KICK_1;
            else if (currentComboState == ComboState.KICK_1)
                //move to kick2
                currentComboState++;

            activateTimerToReset = true;
            currentComboTimer = defaultComboTimer;

            if (currentComboState == ComboState.KICK_1)
                playerAnim.Kick_1();

            if (currentComboState == ComboState.KICK_2)
                playerAnim.Kick_2();
        }
    }

    void ResetComboState()
    {
        if (activateTimerToReset)
        {
            currentComboTimer -= Time.deltaTime;

            if (currentComboTimer <= 0)
            {
                currentComboState = ComboState.NONE;

                activateTimerToReset = false;
                currentComboTimer = defaultComboTimer;
            }
        }
    }
}
