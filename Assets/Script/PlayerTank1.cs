using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank1 : MonoBehaviour {

    Rigidbody rb;
    string movementAxis, turnAxis;
    float movementValue, turnValue;
    float moveSpeed = 20f;
    float turnSpeed=200f;
    // Use this for initialization
    void Awake()
    {
        movementAxis = "Vertical";
        turnAxis = "Horizontal";

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb = GetComponent<Rigidbody>();
        movementValue = Input.GetAxis(movementAxis);
        turnValue = Input.GetAxis(turnAxis);


        Move();
        Turn();

    }

    private void Move()
    {
        Vector3 movement = transform.forward * movementValue * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
    }
    private void Turn()
    {
        float turn = turnValue * turnSpeed * Time.deltaTime;
        Quaternion rot = Quaternion.Euler(0, turn, 0);

        rb.MoveRotation(transform.rotation * rot);
    }

}

