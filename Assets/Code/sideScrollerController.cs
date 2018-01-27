using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sideScrollerController : MonoBehaviour {

    public Vector2 stepVec;
    private Rigidbody2D rb2D;
    public Transform gun;

    #region Numbers

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
    public float gunSmooth = 0.4f;

    #endregion

    #region Bools

    public bool canJump = false;
    public bool isJumping = false;

    #endregion

    public Camera cam;
    public AudioSource audio;
    public ProjectileWeapon gunObject;

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
        ControlWeaponRotationAndPosition();
        ControlWeapon();
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

    void ControlWeapon()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            gunObject.HandleInput();
        }
    }

    void ControlWeaponRotationAndPosition()
    {
        gun.position = transform.position + new Vector3(0, 1, 0);

        Vector3 mouse = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10));

        float AngleRad = Mathf.Atan2(mouse.y - gun.position.y, mouse.x - gun.position.x);
        float angle = (180 / Mathf.PI) * AngleRad;

        gun.rotation = Quaternion.Lerp(gun.rotation, Quaternion.AngleAxis(angle, Vector3.forward), gunSmooth);
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
