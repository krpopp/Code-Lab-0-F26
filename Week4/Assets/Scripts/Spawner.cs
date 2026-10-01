using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject dropObject;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Instantiate(dropObject, transform.position, Quaternion.identity);
        //Invoke("MakeDrop", 2f);
        InvokeRepeating("MakeDrop", 0f, 2f);
    }

    void MakeDrop()
    {
        Instantiate(dropObject, transform.position, Quaternion.identity);
    }
}
