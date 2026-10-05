using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{

    //references to the keys we're moving our player with
    InputAction leftKey;
    InputAction rightKey;

    //varirable that controls how fast we move
    public float speed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set the input variables
        leftKey = InputSystem.actions.FindAction("Left");
        rightKey = InputSystem.actions.FindAction("Right");
    }

    // Update is called once per frame
    void Update()
    {
        //create a local variable, set it to our current position
        Vector3 newPosition = transform.position;
        //if the A key is pressed
        if (leftKey.IsPressed())
        {
            //decrease the x value of new position
            newPosition.x -= speed * Time.deltaTime;
        }
        //if the D key is pressed
        if (rightKey.IsPressed())
        {
            //increase the x value of new position
            newPosition.x += speed * Time.deltaTime;
        }
        //set our position to the new position
        transform.position = newPosition;
    }
}
