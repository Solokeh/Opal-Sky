using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJump : MonoBehaviour {
    public float jumpForce = 0.5f;
    public float groundDistanceCheck = 1.1f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool inAir = false, inAirButtonReleased = false;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        JumpInput();
    }

    private void JumpInput() {
        if (CheckForGround()) {
            inAir = false;
            inAirButtonReleased = false;
            if (Input.GetButton("Jump")) {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                inAir = true;
            }
        } else {
            inAir = true;
            if (Input.GetButtonUp("Jump")) {
                inAirButtonReleased = true;
            }
        }
    }

    private bool CheckForGround() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundDistanceCheck, groundLayer);
        if (hit) {
            return (true);
        }
        return (false);
    }

    public bool InAir {
        get {
            return (inAir);
        }
    }

    public bool InAirButtonReleased {
        get {
            return (inAirButtonReleased);
        }
    }
}
