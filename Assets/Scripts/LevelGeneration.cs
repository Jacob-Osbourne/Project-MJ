using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    [Header("Platform Objects")]
    public GameObject startPlatform;
    public GameObject[] listOfPlatforms;
    public GameObject parentObject;
    public GameObject prevPlatform;
    public GameObject currPlatform;

    [Header("Misc")]
    public int platformChoice;
    public float spaceBetween = 20f;

   


    // Start is called before the first frame update
    void Start()
    {
        platformChoice = Random.Range(0, listOfPlatforms.Length);
        prevPlatform = startPlatform;
        currPlatform = Instantiate(listOfPlatforms[platformChoice], parentObject.transform.position + (transform.right * spaceBetween), new Quaternion(0f,0f,0f,0f));
        currPlatform.transform.parent = parentObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Camera.main.transform.position.x > currPlatform.transform.position.x)
        {
            Destroy(prevPlatform.gameObject);
            prevPlatform = currPlatform;
            platformChoice = Random.Range(0, listOfPlatforms.Length);
            currPlatform = Instantiate(listOfPlatforms[platformChoice], prevPlatform.transform.position + (transform.right * spaceBetween), new Quaternion(0f, 0f, 0f, 0f));
            currPlatform.transform.parent = parentObject.transform;
        } 
    
    }
}
