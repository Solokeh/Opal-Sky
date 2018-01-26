using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sideScrollerController : MonoBehaviour {

    public Vector2 stepVec;
    private Rigidbody2D rb2D;

    public float skidSmooth = 0.1f;
    public float moveSpeed = 1f;
    public float moveSmooth = 0.1f;
    public float downForce = 0f;
    public float distFromGround = 0;
    public float timeOffGroundVal = 0;
    public float maxSpeed = 5f;
    public float jumpForce = 5.1f;
    public float jumpSmooth = 0.3f;
    public float downForceCurve = 0.01f;
    public float maxDownForce = 2.5f;
    public float maxTimeOffGround = 2f;
    public float camSmooth = 0.3f;
    public float timeOffGroundAdd = 0.1f;

    public bool canJump = false;
    public bool isJumping = false;

    public Camera cam;
    public AudioSource audio;

    void Start ()
    {
        audio = GetComponent<AudioSource>();
        rb2D = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate ()
    {
        Movement();
        CheckGround();
        LimitVelocity();
        ControlCam();
	}
    
    void Rotation()
    {

    }

    void ControlCam()
    {
        cam.transform.position = Vector3.Lerp(cam.transform.position, transform.position + new Vector3(0, 0, -10), camSmooth);
    }

    private void Movement()
    {
        stepVec = Vector2.Lerp(stepVec, new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")), skidSmooth);

        stepVec = Vector2.ClampMagnitude(stepVec, 1f);

        float angle = (Mathf.Atan2(stepVec.y, stepVec.x) * 180 / Mathf.PI) + 90;

        rb2D.MovePosition(Vector3.Lerp(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x, transform.position.y) + new Vector2(stepVec.x * moveSpeed, downForce), moveSmooth));

        if(Input.GetButton("Jump") && canJump && !isJumping)
        {
            isJumping = true;
            downForce = 5f;
        }

        if (isJumping)
        {
            if (timeOffGroundVal < maxTimeOffGround)
            {
                downForce = Mathf.Lerp(downForce, 0, jumpSmooth);
            }
            else
            {
                isJumping = false;
            }
        }
    }

    void CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, -1.1f, 0), -Vector2.up);

        if((hit) && (hit.transform.tag == "Ground"))
        {
            distFromGround = hit.distance;
        }

        if(distFromGround >= 0.01f)
        {
            timeOffGroundVal += timeOffGroundAdd;
            if (!isJumping && downForce >= -maxDownForce)
            {
                downForce -= downForce + timeOffGroundVal + downForceCurve;
            }
            canJump = false;
        }
        else
        {
            canJump = true;
            timeOffGroundVal = 0;
            if(!isJumping)
            {
                downForce = 0;
            }

        }
    }

    void LimitVelocity()
    {
        if(rb2D.velocity.magnitude >= maxSpeed)
        {
            rb2D.velocity = rb2D.velocity.normalized * maxSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Coin")
        {
            Destroy(collision.gameObject);
            audio.Play();
        }
    }

}
