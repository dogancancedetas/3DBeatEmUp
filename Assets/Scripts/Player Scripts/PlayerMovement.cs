using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterAnimation playerAnim;
    private Rigidbody myBody;

    public float walkSpeed = 2;
    public float zSpeed = 1.5f;
    private float rotationY = -90;

    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        playerAnim = GetComponentInChildren<CharacterAnimation>();
    }

    // Update is called once per frame
    private void Update()
    {
        RotatePlayer();
        AnimatePlayerWalk();
    }

    void FixedUpdate()
    {
        DetectMovement();
    }

    //Movement
    void DetectMovement()
    {
        myBody.velocity = new Vector3(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) * (-walkSpeed), myBody.velocity.y, Input.GetAxisRaw(Axis.VERTICAL_AXIS) * (-zSpeed));
    }

    //Rotation
    void RotatePlayer()
    {
        if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) > 0)
            transform.rotation = Quaternion.Euler(0, -Mathf.Abs(rotationY), 0);
        else if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) < 0)
            transform.rotation = Quaternion.Euler(0, Mathf.Abs(rotationY), 0);
    }

    void AnimatePlayerWalk()
    {
        if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) != 0 || Input.GetAxisRaw(Axis.VERTICAL_AXIS) != 0)
            playerAnim.Walk(true);
        else
            playerAnim.Walk(false);
    }
}
