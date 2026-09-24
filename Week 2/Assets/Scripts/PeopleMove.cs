using UnityEngine;

public class PeopleMove : MonoBehaviour
{

    //variables: you must declare the data type, like in processing
    //public changes the variable's scope BUT! we're just using it to see the variable in the inspector for now
    
    public float score = 0.5f; //floating point number (number that can have a decimal)
    public int lives = 3; //integer (whole number)
    public string name = "Bob"; //words
    public bool gameOver = false; //true or false

    //how much to move each frame
    public float speed;
    
    //the position we want to move towards
    public Vector3 targetPosition;

    //there are also vector 2s in Unity
    Vector2 twoDeePosition;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //print the string "Hello World!" to the console
        //Debug.Log("Hello World!");
        //print the string variable called name to the console
        Debug.Log(name);
    }

    // Update is called once per frame
    void Update()
    {
        //print the string "Run Forever" continuously to the console
        //Debug.Log("Run Forever");
        
        //move to the target position
        //longer version: find the next step position between
        //point A (transform.position) and point B (targetPosition)
        //Time.deltaTime is the time since the last frame
        //(it lets us make our speed frame independent
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        //if the score variable is less than 10
        if (score < 10)
        {
            //print the string "you are losing" to the console
            Debug.Log("you are losing");
        }
    }
}
