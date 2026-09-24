using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{

    //reference to the input actions we set in the Inspector
    //need to include "using UnityEngine.InputSystem;" to access
    InputAction upButton;
    InputAction downButton;
    //LONGER VERSION
    //InputAction is the class I want to access; upButton and downButton are the variable names I'm using
    //for the two kinds of input

    //reference to the audio source component on the player
    AudioSource myCDPlayer;
    //LONGER VERSION
    //AudioSource is the class I want to access; myCDPlayer is the variable name I'm using
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set the reference to the up button action
        upButton = InputSystem.actions.FindAction("Up");
        downButton = InputSystem.actions.FindAction("Down");

        //set the reference to the audio source component
        myCDPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //local variable referencing the game object's current position
        //local variable means that it's only accessible to Update
        Vector3 playerPosition = transform.position;
        
        //if anything categorized as "Up" in the Input System is pressed
        if (upButton.IsPressed())
        {
            //increase the y value of the position variable
            //(we multiply our change by Time.deltaTime to make the movement frame independent)
            playerPosition.y += 2 * Time.deltaTime;
            Debug.Log("go up");
        }
        //same thing, but for going down
        if (downButton.IsPressed())
        {
            playerPosition.y -= 2 * Time.deltaTime;
        }
        
        //set the game object's position to the new position calculated
        transform.position = playerPosition;
    }

    //fires once when the player object's hit box touches another object
    //other gives us access the information about the collision (ex: what we collided with)
    //for this function to run, both colliding objects need collider components
    //also, one of the objects needs a rigidbody
    //and the other must be set to "Is Trigger" in the editor
    void OnTriggerEnter(Collider other)
    {
        //play whatever sound is in the audio source
        myCDPlayer.Play();
        Debug.Log("touched something");
    }
}
