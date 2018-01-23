using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipController : MonoBehaviour
{

    private Rigidbody2D rb2D;
    public float speed = 1;
    public Camera cam;
    private healthManager health;
    public float turnSmooth = 0.2f;
    public float maxSpeed = 20f;
    public float camSmooth = 0.1f;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        health = GetComponent<healthManager>();
    }

    private void Update()
    {

    }

    void FixedUpdate()
    {
        if (health.isDead)
        {

        }
        else
        {
            ControlCam();
            Movement();
            Rotation();
        }
    }

    void ControlCam()
    {
        cam.transform.position = Vector3.Lerp(cam.transform.position, transform.position + new Vector3(0, 0, -10), camSmooth);
    }

    void LimitVelocity()
    {
        if(rb2D.velocity.magnitude > maxSpeed)
        {
            rb2D.velocity = rb2D.velocity.normalized * maxSpeed;
        }
    }

    void Movement()
    {
        rb2D.AddForce(transform.right * Input.GetAxis("Vertical") * speed);
    }

    void Rotation()
    {
        Vector3 mouse = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10));

        float AngleRad = Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x);
        float angle = (180 / Mathf.PI) * AngleRad;

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), turnSmooth);
    }
}
