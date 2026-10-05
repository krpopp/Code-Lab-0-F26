using UnityEngine;

public class Spawner : MonoBehaviour
{

    //reference to the object we want to spawn
    //we set this in the inspector by clicking and dragging to object in
    public GameObject dropObject;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Instantiate(dropObject, transform.position, Quaternion.identity);
        //Invoke("MakeDrop", 2f);
        
        //runs the stated function after 0 seconds every 2 seconds
        InvokeRepeating("MakeDrop", 0f, 2f);
    }

    //function that i created and declared to spawn new objects
    void MakeDrop()
    {
        //create the drop object at this script's position with its base rotation
        Instantiate(dropObject, transform.position, Quaternion.identity);
    }
}
