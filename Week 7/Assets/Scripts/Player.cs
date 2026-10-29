using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //reference to move input scheme
    private InputAction moveInput;

    //tracks input
    private Vector3 toMove;

    //reference to rigidbody and animator components on the attached gameobject
    private Rigidbody2D myBody;
    private Animator myAnimator;

    //speed we want to move
    public float speed;

    //reference to sprite renderer component
    private SpriteRenderer myRenderer;

    //the sizes we want to scale to
    public Vector3 targetScale;
    public Vector3 targetScaleTiny;

    //tracks if we are currently scaling
    private bool isScaling;
    private bool isScalingTiny;

    //how quickly we want to change our scale
    public float changeSpeed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set input
        moveInput = InputSystem.actions.FindAction("Move");

        //set component references
        myAnimator = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
        myRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //set what will be our velocity to moveInput, multiplied by delta time and speed
        toMove = moveInput.ReadValue<Vector2>() * Time.fixedDeltaTime * speed;

        //if we're moving this frame
        if (toMove != Vector3.zero)
        {
            //set the walking animation to true
            myAnimator.SetBool("walking", true);

            //if we're moving left
            if (toMove.x < 0)
            {
                //flip the sprite 
                myRenderer.flipX = true;
                //otherwise
            } else if (toMove.x > 0)
            {
                //flip it back
                myRenderer.flipX = false;
            }
        }
        else
        {
            //otherwise, turn off the walking animation
            myAnimator.SetBool("walking", false);
        }

        //if we are scaling up
        if (isScaling == true)
        {
            //set our scale to the next lerp step
            //lerp = linear interpolation
            //it finds a value between A to B (transform.localScale, targetScale) given a rate
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * changeSpeed);
        }

        //if we're scaling down
        if (isScalingTiny == true)
        {
            //same thing (but tiny!)
            transform.localScale = Vector3.Lerp(transform.localScale, targetScaleTiny, Time.deltaTime * changeSpeed);
        }
        //transform.position += toMove;
    }

    //runs at the physics engine step
    void FixedUpdate()
    {
        //move the rigidbody's position by the value found in update
        myBody.MovePosition(transform.position + toMove);
    }

    //fires once, when an overlap event occurs
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if the thing we overlapped with is tagged mushroom
        if (other.gameObject.CompareTag("Mushroom"))
        {
            //set our scaling booleans
            Debug.Log("GET BIGGER");
            isScaling = true;
            isScalingTiny = false;
            //transform.localScale = targetScale;
        }

        //if the thing we overlapped with is tagged gem
        if (other.gameObject.CompareTag("Gem"))
        {
            //set our scaling booleans
            Debug.Log("Get tiny, baby");
            isScaling = false;
            isScalingTiny = true;
        }
    }

}
