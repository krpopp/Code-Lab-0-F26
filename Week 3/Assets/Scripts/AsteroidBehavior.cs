using UnityEngine;

public class AsteroidBehavior : MonoBehaviour
{

    //reference to the target position's transform compenent
    public Transform targetPosition;
    //LONGER VERSION
    //Transform is the class we want to access
    //The transform component contains the position, rotation, and scale of a game object
    //targetPosition is the variable name that we came up with
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //set the asteroid's position to move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, 2 * Time.deltaTime);
        //LONGER VERSION
        //the left hand side of the equals is what we're changing (eg: "Set the position to...")
        //the right hand side is what we're making the position equal to (eg: "... the next step towards the target)
        //Vector3 is a class that contains the function MoveTowards; we access that function with a . after the class name
        //MoveTowards takes 3 parameters:
        //the beginning position we're moving from (in this case, our current position)
        //the position we want to move to
        //and the amount we want to move
        //we're using Time.deltaTime (the time since the last frame) to make our movement frame independent
        //for example: say my computer is suuuper slow and the time since the last frame was 0.5 milliseconds; my asteroid will move by 1 unit
        //but if my computer is running quickly and the time since the last frame was 0.1 milliseconds, my asteroid will move by 0.2 units
        //so the asteroid will move at roughly the same rate no matter the speed of my computer
    }
}
