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

    [Header("Background")]
    public GameObject startBackground;
    public GameObject beforeStartBG;
    public GameObject doubleBefore;
    public float xCompare;
    private GameObject UpBG;
    private GameObject currBG;
    private GameObject prevBG;
    private GameObject prevPrevBG;
    private GameObject prevPrevPrevBG;
    public GameObject bgForward;
    public GameObject bgBackward;
    public bool forward;

   


    // Start is called before the first frame update
    void Start()
    {
        platformChoice = Random.Range(0, listOfPlatforms.Length);
        prevPlatform = startPlatform;
        currPlatform = Instantiate(listOfPlatforms[platformChoice], parentObject.transform.position + (transform.right * spaceBetween), new Quaternion(0f,0f,0f,0f));
        currPlatform.transform.parent = parentObject.transform;

        prevPrevPrevBG = doubleBefore;
        prevPrevBG = beforeStartBG;
        prevBG = startBackground;
        currBG = Instantiate(bgBackward, parentObject.transform.position + (transform.right * spaceBetween) - new Vector3(2.25f, 0, 0), new Quaternion(0f, 0f, 0f, 0f));
        currBG.transform.parent = parentObject.transform;
        UpBG = Instantiate(bgForward, parentObject.transform.position + (transform.right * spaceBetween) - new Vector3(20f, 0, 0), new Quaternion(0f, 0f, 0f, 0f));
        UpBG.transform.parent = parentObject.transform;
        xCompare = 7;
        forward = true;


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

        if (Camera.main.transform.position.x > xCompare )
        {

            xCompare += 17.75f;
            Destroy(prevPrevPrevBG.gameObject);
            prevPrevPrevBG = prevPrevBG;
            prevPrevBG = prevBG;
            prevBG = currBG;
            currBG = UpBG;
            if (forward)
            {
                UpBG = Instantiate(bgForward, new Vector3(xCompare + 10.75f, 0, 0), new Quaternion(0f, 0f, 0f, 0f));
                UpBG.transform.parent = parentObject.transform;
                forward = !forward;
            }
            else
            {
                UpBG = Instantiate(bgBackward, new Vector3(xCompare + 10.75f, 0, 0), new Quaternion(0f, 0f, 0f, 0f));
                UpBG.transform.parent = parentObject.transform;
                forward = !forward;
            }
        }
    
    }
}
