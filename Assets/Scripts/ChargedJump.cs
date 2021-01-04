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
    public bool jumpOnCD = false;

    public float TESTJUMP;

    [Header("Animation Info")]
    public float PlayersY;
    public bool isCharging;
    public bool isFalling;
    public float jumpLeftRight;

    private Rigidbody2D rb;
    private Animator animator;
    private bool jumpNow = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!jumpOnCD)
        {
            if (Input.GetMouseButton(0) && !isJumping)
            {
                chargePower += Time.deltaTime;
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Debug.Log(ray);

                isCharging = true;
                animator.SetBool("isCharging", true);

                jumpLeftRight = (ray.GetPoint(0).x - gameObject.transform.position.x);

                if (jumpLeftRight > 0)
                {
                    animator.SetBool("onRight", true);
                }
                else
                {
                    animator.SetBool("onRight", false);
                }

            }

            if (Input.GetMouseButtonUp(0) && !isJumping && isCharging)
            {

                isCharging = false;
                animator.SetBool("isCharging", false);
                animator.SetBool("Grounded", false);
                animator.SetBool("jumpOnCooldown", true);
                jumpNow = true;
                PlayersY = gameObject.transform.position.y;
            }
        }

        if (PlayersY > gameObject.transform.position.y)
        {
            PlayersY = gameObject.transform.position.y;
            isFalling = true;
            animator.SetBool("isFalling", true);
        }
        else
        {
            PlayersY = gameObject.transform.position.y;
            isFalling = false;
            animator.SetBool("isFalling", false);
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

            animator.SetBool("Grounded", true);
            isJumping = false;
            chargePower = 0;
            jumpOnCD = true;
            StartCoroutine(JumpCooldown());

        }
    }

    IEnumerator JumpCooldown()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("jumpOnCooldown", false);
        jumpOnCD = false;
    }

}
