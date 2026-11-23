using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{

    public float speed;
    InputAction moveAction;

    Rigidbody2D myBody;

    Vector2 startPosition;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        myBody = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector2 newPosition = new Vector2(transform.position.x, transform.position.y);
        newPosition += input * speed * Time.fixedDeltaTime;
        myBody.MovePosition(newPosition);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hazard"))
        {
            transform.position = startPosition;
        }
    }
}
