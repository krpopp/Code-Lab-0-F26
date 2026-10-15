using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class BallControl : MonoBehaviour
{

    public Vector3 velocity;
    public Rigidbody2D myBody;

    InputAction leftClick;
    bool startGame = false;

    public TMP_Text scoreText;

    int score;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftClick = InputSystem.actions.FindAction("LeftClick");
    }

    // Update is called once per frame
    void Update()
    {
        if (leftClick.WasReleasedThisFrame() && startGame == false)
        {
            startGame = true;
        }

        if (startGame == true)
        {
            MoveBall();
        }
    }

    void MoveBall()
    {
        //move the ball's rigidbody by the velocity
        myBody.MovePosition(transform.position + velocity * Time.deltaTime);
    }

    void BounceBall()
    {
        velocity.y = -velocity.y;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        BounceBall();
        if (other.gameObject.CompareTag("Brick"))
        {
            score++;
            scoreText.text = score.ToString();
            Destroy(other.gameObject);
        }
    }
}
