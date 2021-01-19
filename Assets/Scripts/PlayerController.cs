using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    [Header("Jump Settings")]
    public float chargePower = 0f;
    public float force = 150f;
    public float sideForce = 10f;
    public bool isJumping = false;
    public float maxCharge = 2f;
    public Ray ray;
    public bool jumpOnCD = false;
    public bool isGrounded;
    public LayerMask groundMask;

    public float TESTJUMP;

    [Header("Animation Info")]
    public float PlayersY;
    public bool isCharging;
    public bool isFalling;
    public float jumpLeftRight;

    [Header("Player Score")]
    public PlayerScore PlayerScoreScript;

    private Rigidbody2D rb;
    private Animator animator;
    private bool jumpNow = false;
    public bool isDead = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isDead = false;
    }

    void Update()
    {
        if (!jumpOnCD)
        {
            if (Input.GetMouseButton(0) && !isJumping)
            {
                chargePower += Time.deltaTime;
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                //Debug.Log(ray);

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

        isGrounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x - 0.4f, gameObject.transform.position.y - 0.87f), new Vector2(0.45f, 0.2f), 0f, groundMask);

        if (isGrounded)
        {
            isJumping = false;
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

            
            //rb.AddForce(rb.transform.up * (chargePower + 1) * force);

            Debug.Log("UP FORCE: " + (rb.transform.up * (chargePower + 1) * force));

            float rightForce = (ray.GetPoint(0).x - gameObject.transform.position.x);
            //rb.AddForce(rb.transform.right * rightForce * (chargePower + 1) * sideForce);

            Debug.Log("RIGHT FORCE: " + (rb.transform.right * rightForce * (chargePower + 1) * sideForce));

            //Debug.Log(rightForce);

            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector2 ((rightForce * (chargePower + 1) * sideForce), (chargePower + 1) * force));

            jumpNow = false;
            isJumping = true;
            
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("Grounded", true);
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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeathZone"))
        {
            // death bool
            isDead = true;
            //save score
            PlayGamesScript.AddScoreToLeaderboard(GPGSIds.leaderboard_high_scores, (long)PlayerScoreScript.scoreMax);
            float playerHighScore = PlayerPrefs.GetFloat("HighScore");
            if (PlayerScoreScript.scoreMax > playerHighScore)
            {
                PlayerPrefs.SetFloat("HighScore", PlayerScoreScript.scoreMax);
            }
        }
        //add collision detection for other objects and cue death animation from here
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x -0.4f, gameObject.transform.position.y - 0.87f), new Vector2(0.45f, 0.2f));
    }

}
