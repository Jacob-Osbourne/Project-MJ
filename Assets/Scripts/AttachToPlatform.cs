using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToPlatform : MonoBehaviour
{

    public bool isEnabled = false;
    // Start is called before the first frame update
    void Update()
    {
        isEnabled = true;
    }



    
        
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && isEnabled)
        {

            other.gameObject.transform.parent = transform;

        }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && isEnabled)
        {
            other.gameObject.transform.parent = null;
        }
    }
}
