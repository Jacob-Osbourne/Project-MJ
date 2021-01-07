using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformHorz : MonoBehaviour
{
    [Header("SetupInfo")]
    public float maxRightOfOrigin;
    public float maxLeftOfOrigin;
    public bool goingRight;

    private float myMaxR;
    private float myMaxL;



    // Start is called before the first frame update
    void Start()
    {
        int startNum = Random.Range(0, 2);
        if (startNum == 0)
        {
            goingRight = true;
        }
        else
        {
            goingRight = false;
        }

        myMaxR = this.gameObject.transform.position.x + maxRightOfOrigin;
        myMaxL = this.gameObject.transform.position.x - maxLeftOfOrigin;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.x < myMaxR && goingRight)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + Time.deltaTime, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        }
        else if (this.gameObject.transform.position.x > myMaxL && !goingRight)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x - Time.deltaTime, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        }

        if (this.gameObject.transform.position.x > myMaxR )
        {
            goingRight = false;
        }
        if (this.gameObject.transform.position.x < myMaxL)
        {
            goingRight = true;
        }
    }
}
