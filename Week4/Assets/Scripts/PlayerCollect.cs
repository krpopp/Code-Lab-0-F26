using UnityEngine;
using TMPro;

public class PlayerCollect : MonoBehaviour
{

    //get access to the text component we're displaying score with
    //we set this in the inspector by clicking and dragging the text object over
    public TMP_Text scoreUI;
    
    //declare and set the initial score variable
    float score = 0f;

    void Start()
    {
        //set the text to be 0
        //since the score is a number, we have to translate it to a string (word)
        scoreUI.text = score.ToString();
    }
    
    //runs when a collision first occurs
    //the 'collision' parameter returns info about the collision
    void OnCollisionEnter(Collision collision)
    {
        //if the thing we hit is tagged "collect" (which we set in the inspector)
        if (collision.gameObject.CompareTag("Collect"))
        {
            //increase the score
            score++;
            //update the score UI
            scoreUI.text = score.ToString();
            //show what the score is and that we hit in the console
            Debug.Log("the score is " + score);
            Debug.Log("hit a drop object");
            //destroy the thing we hit
            Destroy(collision.gameObject);
        }
    }

    //runs when an overlap first occurs
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("overlapped with something");
    }

    //runs when an overlap ends
    void OnTriggerExit(Collider other)
    {
        Debug.Log("something left :(");
    }

    //runs continuously as long as an overlap is occuring
    void OnTriggerStay(Collider other)
    {
        Debug.Log("something is here :)");
    }
}
