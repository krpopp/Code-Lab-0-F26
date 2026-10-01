using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{

    InputAction leftKey;
    InputAction rightKey;

    public float speed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftKey = InputSystem.actions.FindAction("Left");
        rightKey = InputSystem.actions.FindAction("Right");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;
        if (leftKey.IsPressed())
        {
            newPosition.x -= speed * Time.deltaTime;
        }
        if (rightKey.IsPressed())
        {
            newPosition.x += speed * Time.deltaTime;
        }
        transform.position = newPosition;
    }
}
