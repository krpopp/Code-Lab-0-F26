using UnityEngine;

public class Hazard : MonoBehaviour
{

    Vector2 startPosition;
    public float speed;
    Rigidbody2D myBody;

    public bool bounce;

    public Transform moveToObj;
    Vector3 moveTo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
        myBody = GetComponent<Rigidbody2D>();

        moveTo = moveToObj.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = Vector3.MoveTowards(transform.position, moveTo, speed * Time.fixedDeltaTime);
        myBody.MovePosition(newPosition);

        //if we've nearly reached the target position
        if (Vector2.Distance(transform.position, moveTo) < 0.1f)
        {
            //if this is a bouncing hazard
            if (bounce)
            {
                //if we were moving to the target object
                if (moveTo == moveToObj.position)
                {
                    //change to move to our start position
                    moveTo = startPosition;
                }
                else
                {
                    //otherwise, move to the target object
                    moveTo = moveToObj.position;
                }
            }
            else
            {
                //go back to the starting position
                transform.position = startPosition;
            }
        }
    }
}
