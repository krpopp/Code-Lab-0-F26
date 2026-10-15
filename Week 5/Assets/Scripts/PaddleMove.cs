using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleMove : MonoBehaviour
{
    public float minX;
    public float maxX;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        if (mousePosition.x > minX && mousePosition.x < maxX)
        {
            transform.position = new Vector3(mousePosition.x, transform.position.y, transform.position.z); 
        }
    }
}
