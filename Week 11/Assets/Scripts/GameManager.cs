using UnityEngine;

public class GameManager : MonoBehaviour
{


    public GameObject bounceObj;

    public Transform[] targets;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector3 newPosition = Vector3.zero;
            newPosition.x = Random.Range(-9, 9);
            newPosition.y = Random.Range(-5, 5);
            GameObject newObj = Instantiate(bounceObj, newPosition, Quaternion.identity);

            int randomNum = Random.Range(0, 2);

            newObj.GetComponent<Hazard>().moveToObj = targets[randomNum];

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
