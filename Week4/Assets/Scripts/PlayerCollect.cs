using UnityEngine;
using TMPro;

public class PlayerCollect : MonoBehaviour
{

    public TMP_Text scoreUI;
    
    float score = 0f;

    void Start()
    {
        scoreUI.text = score.ToString();
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collect"))
        {
            score++;
            scoreUI.text = score.ToString();
            Debug.Log("the score is " + score);
            Debug.Log("hit a drop object");
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("overlapped with something");
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("something left :(");
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("something is here :)");
    }
}
