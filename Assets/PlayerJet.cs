using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJet : MonoBehaviour {
    [SerializeField]
    private int fuel = 100;
    [SerializeField]
    private int maxFuel = 100;
    public float fuelRefillDelay = 2f;
    public PlayerJump playerJumpScript;
    public float jetForce = 2f;

    private Rigidbody2D rb;
    private float jetIdleTimer = 0f;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (jetIdleTimer > 0f) {
            jetIdleTimer -= Time.deltaTime;
        } else {
            Fuel++;
        }
        JetInput();
    }

    private void JetInput() {
        if ((Input.GetButton("Jump")) && (playerJumpScript.InAirButtonReleased)) {
            Fuel--;
            jetIdleTimer = fuelRefillDelay;
            rb.AddForce(Vector2.up * jetForce);
        }
    }

    public int Fuel {
        get {
            return (fuel);
        }
        set {
            fuel = value;
            if (fuel < 0) {
                fuel = 0;
            } else if (fuel > maxFuel) {
                fuel = maxFuel;
            }
        }
    }

    public int MaxFuel {
        get {
            return (maxFuel);
        }
    }
}
