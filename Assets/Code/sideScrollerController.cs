using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sideScrollerController : MonoBehaviour {

    public Vector2 stepVec;
    private Rigidbody2D rb2D;
    public float skidSmooth = 0.1f;
    public float moveSpeed = 1f;
    public float moveSmooth = 0.1f;

	void Start ()
    {
        rb2D = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
		
	}
    
    void Rotation()
    {

    }

    private void Movement()
    {
        stepVec = Vector2.Lerp(stepVec, new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")), skidSmooth);

        stepVec = Vector2.ClampMagnitude(stepVec, 1f);

        float angle = (Mathf.Atan2(stepVec.y, stepVec.x) * 180 / Mathf.PI) + 90;

        rb2D.MovePosition(Vector3.Lerp(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x, transform.position.y) + new Vector2(stepVec.x, stepVec.y) * moveSpeed, moveSmooth));
    }
}
