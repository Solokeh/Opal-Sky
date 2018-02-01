using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJump : GroundCheck {
    public Stats stats;

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
                rb.AddForce(Vector2.up * stats.JumpForce, ForceMode2D.Impulse);
                inAir = true;
            }
        } else {
            inAir = true;
            if (Input.GetButtonUp("Jump")) {
                inAirButtonReleased = true;
            }
        }
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
