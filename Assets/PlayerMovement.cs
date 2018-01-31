using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {
    public Stats stats;
    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        Movement();
    }

    private void Movement() {
        Vector2 pos = transform.position;
        float horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * stats.Speed, rb.velocity.y);
    }
}
