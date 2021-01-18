using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToPlatform : MonoBehaviour
{
    public PlayerController pc;
    public bool isEnabled = false;

    private void Start()
    {
        if (pc == null)
        {
            pc = FindObjectOfType<PlayerController>();
        }
    }
    // Start is called before the first frame update
    void Update()
    {
        isEnabled = true;
    }
    
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && isEnabled && pc.isGrounded)
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
