using UnityEngine;

public class Hazard : MonoBehaviour
{

    Vector2 startPosition;
    public float speed;
    Rigidbody2D myBody;

    public bool bounce;

    public Transform moveToObj;
    Vector3 targetPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
        myBody = GetComponent<Rigidbody2D>();

        targetPosition = moveToObj.position;
    }

    // Update is called once per frame
    void Update()
    {
        //move to a target position
        Vector2 newPosition = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.fixedDeltaTime);
        myBody.MovePosition(newPosition);

        //if we've nearly reached the target position
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            //if this is a bouncing hazard
            if (bounce)
            {
                BounceBack();
            }
            else
            {
                RestartPosition();
            }
        }
    }

    void BounceBack()
    {
        //if we were moving to the target object
        if (targetPosition == moveToObj.position)
        {
            //change to move to our start position
            targetPosition = startPosition;
        }
        else
        {
            //otherwise, move to the target object
            targetPosition = moveToObj.position;
        }
    }

    void RestartPosition()
    {
        //go back to the starting position
        transform.position = startPosition;
        
    }
}
