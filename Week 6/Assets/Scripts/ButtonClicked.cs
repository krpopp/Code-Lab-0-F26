using UnityEngine;

public class ButtonClicked : MonoBehaviour
{

    public GameManager myManager;
    
    public void Pressed(int princess)
    {
        myManager.AnsweredQuestion(princess);
        //Debug.Log("pressed a button");
    }
}
