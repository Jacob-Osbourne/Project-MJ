using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargedJump : MonoBehaviour
{

    [Header("Jump Settings")]
    public float chargePower = 0f;
    public float force = 0f;
    public float sideForce = 0f;
    public bool isJumping = false;
    public float maxCharge = 0f;
    public Ray ray;

    private Rigidbody2D rb;
    private bool jumpNow = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            chargePower += Time.deltaTime;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.Log(ray);

        }

        if (Input.GetMouseButtonUp(0) && !isJumping)
        {
            jumpNow = true;
        }
    }

    private void FixedUpdate()
    {
        if (jumpNow && !isJumping)
        {
            if (chargePower > maxCharge)
            {
                chargePower = maxCharge;
            }

            
            rb.AddForce(rb.transform.up * (chargePower + 1) * force);

            float rightForce = (ray.GetPoint(0).x - gameObject.transform.position.x);
            rb.AddForce(rb.transform.right * rightForce * (chargePower + 1) * sideForce);
            
            Debug.Log(rightForce);

            jumpNow = false;
            isJumping = true;
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            chargePower = 0;
        }
    }

}
