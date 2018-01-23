using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpPower;

    private Rigidbody2D _rigidbody2D;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _rigidbody2D.AddForce(new Vector2(0, JumpPower), ForceMode2D.Impulse);
        }

        transform.position += transform.right * -MoveSpeed * Time.deltaTime * -Input.GetAxis("Horizontal");
    }

    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position - new Vector3(0, 1.1f), -Vector2.up, .1f);
        Debug.DrawRay(transform.position - new Vector3(0, 1.1f), -Vector2.up * .1f);
        return hit;
    }
}
