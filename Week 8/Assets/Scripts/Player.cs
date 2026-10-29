using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //declare reference to WASD inputs
    private InputAction moveInput;

    //amount of force we want to add to the player
    //public float force;
    
    //speed and power for movement and jumping
    public float speed;
    public float jumpPower;
    
    //reference to the attached gameobject's rigidbody
    public Rigidbody2D myBody;
    //to track the vector returned by moveInput
    private Vector2 inputForce;

    //transform of object childed to the player (reference point for if we touched the ground)
    public Transform groundChecker;
    //radius of circle where we check if we touched the ground
    public float checkSize;
    //layer that the ground is in 
    public LayerMask groundLayer;

    //tracks if we're on the ground layer or not
    private bool onGround;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set the move inputs
        moveInput = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        //set the vector the player has input
        //left is x = -1; right is x = 1
        //down is y = -1; up is y = 1
        inputForce = moveInput.ReadValue<Vector2>();
    }

    //event function where we put physics stuff
    //runs at the same rate as the physics engine
    private void FixedUpdate()
    {
        //adds force like a 'push' to the body
        //myBody.AddForce(inputForce * force);
        
        //set the x velocity to the horizontal input direction, multiplied by the speed
        myBody.linearVelocityX = inputForce.x * speed;
        
        //if we pressed the up input and the player is on the ground
        if (inputForce.y > 0 && onGround)
        {
            //set the y velocity to the vertical input direction, multiplied by the jump power
            myBody.linearVelocityY = inputForce.y * jumpPower;
            //set that we are no longer on the ground
            onGround = false;
        }
        else
        {
            //otherwise (if we're not on the ground or aren't pressing the up input)
            //check if a circle at the position of the ground checker, with a radius of checkSize
            //is overlapping with something in the ground layer
            onGround = Physics2D.OverlapCircle(groundChecker.position, checkSize, groundLayer);
        }
    }
}
