using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public PlayerController player;
    public Vector3 offset;
    //public float smoothSpeed = 0.125f;


    // Start is called before the first frame update
    void Start()
    {
       if (player == null)
        {
            player = FindObjectOfType<PlayerController>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        transform.position = new Vector3 (player.transform.position.x, this.transform.position.y, this.transform.position.z) + offset;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        //transform.position = smoothedPosition;

       //transform.LookAt(player.transform);
    }
}
