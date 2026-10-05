using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    //function i created to start the game
    //because i want to attach this script to a button, i declared it as public
    //meaning that other objects (other scripts) can use this function
    public void StartPressed()
    {
        //load the game scene
        //to use the scene manager, i needed to add the scenemanagement namespace at the top of this script
        SceneManager.LoadScene("Game");
        Debug.Log("clicked button");
    }
}
