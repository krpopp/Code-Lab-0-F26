using UnityEngine;

public class ButtonClicked : MonoBehaviour
{

    //reference to my game manager script
    public GameManager myManager;
    
    //go to the next question
    //we set a button to use this function in the inspector
    public void Pressed(int princess)
    {
        //calling a function from the game manager
        myManager.AnsweredQuestion(princess);
        //Debug.Log("pressed a button");
    }
}
