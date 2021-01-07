using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRock : MonoBehaviour
{
    public bool shaking = false;
    public bool fall = false;
    public Vector3 left;
    public Vector3 right;
    public AttachToPlatform attach;
    public bool once = true;
    // Start is called before the first frame update
    void Start()
    {
        left = this.transform.position - new Vector3(0.05f, 0, 0);
        right = this.transform.position + new Vector3(0.05f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (shaking)
        {
            float pingPong = Mathf.PingPong(Time.time * 15, 1);
            transform.position = Vector3.Lerp(left, right, pingPong);
        }

        if (fall)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - (Time.deltaTime * 8), this.gameObject.transform.position.z);
        }

        if (this.gameObject.transform.position.y < -20)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (once)
            {
                shaking = true;
                StartCoroutine(fallingCountdown());
                once = false;
            }
            
        }
    }

    IEnumerator fallingCountdown()
    {
        yield return new WaitForSeconds(5f);
        shaking = false;
        yield return new WaitForSeconds(0.1f);
        attach.enabled = true;
        yield return new WaitForSeconds(0.3f);
        fall = true;
    }

}
