using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformVertical : MonoBehaviour
{
    [Header("SetupInfo")]
    public float maxAboveOrigin;
    public float maxBelowOrigin;
    public bool goingUp;

    private float myMax;
    private float myMin;


    
    // Start is called before the first frame update
    void Start()
    {
        int startNum = Random.Range(0, 2);
        if (startNum == 0)
        { 
            goingUp = true;
        }
        else
        {
            goingUp = false;
        }

        myMax = this.gameObject.transform.position.y + maxAboveOrigin;
        myMin = this.gameObject.transform.position.y - maxBelowOrigin;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.y < myMax && goingUp)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + Time.deltaTime, this.gameObject.transform.position.z);
        }
        else if (this.gameObject.transform.position.y > myMin && !goingUp)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - Time.deltaTime, this.gameObject.transform.position.z);
        }

        if (this.gameObject.transform.position.y > myMax )
        {
            goingUp = false;
        }
        if (this.gameObject.transform.position.y < myMin)
        {
            goingUp = true;
        }
    }
}
