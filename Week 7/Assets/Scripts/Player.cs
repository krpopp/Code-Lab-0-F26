using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private InputAction moveInput;

    private Vector3 toMove;

    private Rigidbody2D myBody;
    private Animator myAnimator;

    public float speed;

    private SpriteRenderer myRenderer;

    public Vector3 targetScale;
    public Vector3 targetScaleTiny;

    private bool isScaling;
    private bool isScalingTiny;
    public float changeSpeed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveInput = InputSystem.actions.FindAction("Move");
        myAnimator = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
        myRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        toMove = moveInput.ReadValue<Vector2>() * Time.fixedDeltaTime * speed;
        if (toMove != Vector3.zero)
        {
            myAnimator.SetBool("walking", true);
            if (toMove.x < 0)
            {
                myRenderer.flipX = true;
            } else if (toMove.x > 0)
            {
                myRenderer.flipX = false;
            }
        }
        else
        {
            myAnimator.SetBool("walking", false);
        }

        if (isScaling == true)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * changeSpeed);
        }

        if (isScalingTiny == true)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScaleTiny, Time.deltaTime * changeSpeed);
        }
        //transform.position += toMove;
    }

    void FixedUpdate()
    {
        myBody.MovePosition(transform.position + toMove);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Mushroom"))
        {
            Debug.Log("GET BIGGER");
            isScaling = true;
            isScalingTiny = false;
            //transform.localScale = targetScale;
        }

        if (other.gameObject.CompareTag("Gem"))
        {
            Debug.Log("Get tiny, baby");
            isScaling = false;
            isScalingTiny = true;
        }
    }

}
