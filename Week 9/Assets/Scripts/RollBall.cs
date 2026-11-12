using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector3 = UnityEngine.Vector3;

public class RollBall : MonoBehaviour
{

    Rigidbody rigidBody;

    InputAction bowlButt;

    bool holdingButt;
    bool roll;

    public float rollPower;

    public LayerMask personLayer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        bowlButt = InputSystem.actions.FindAction("Bowl");
        //rigidBody.AddForce(transform.forward * 1000f);
    }

    // Update is called once per frame
    void Update()
    {
        if (bowlButt.WasPressedThisFrame())
        {
            holdingButt = true;
            //StartRoll();
        } else if (bowlButt.WasReleasedThisFrame())
        {
            holdingButt = false;
            roll = true;
        }
        //Debug.Log(CallculateGrade(20, -10));
    }

    void FixedUpdate()
    {
        if (holdingButt && rigidBody.linearVelocity == Vector3.zero)
        {
            //find the direction the mouse is pointing towards
            Debug.DrawRay(transform.position, FindDirection() * 1000f, Color.red);
        }

        if (roll)
        {
            StartRoll();
            //roll the ball based on the mouse's direction
        }
    }

    void StartRoll()
    {
        //if I am NOT touching/looking at a player
        if (Physics.Raycast(transform.position, FindDirection(), 1000f, personLayer) == false)
        {
            rigidBody.isKinematic = false;
            rigidBody.AddForce(rollPower * transform.TransformDirection(FindDirection()), ForceMode.Impulse);
            roll = false;
        }
    }

    Vector3 FindDirection()
    {
        Vector3 mousePosition = Mouse.current.position.ReadValue();
        mousePosition.z = 10f;
        Vector3 direction = Camera.main.ScreenToWorldPoint(mousePosition);
        direction.z = 10f;
        Debug.Log(direction);
        return direction.normalized;
    }

    int CallculateGrade(int a, int b)
    {
        return a + b;
    }
}
