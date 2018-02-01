using UnityEngine;

public class PlayerPlatformDropThrough : MonoBehaviour {
    [Tooltip("The time (in seconds) to ignore collision between the Player and platform.")]
    public float disableCollisionTime = 1f;
    [Tooltip("The distance of the raycast which checks for any platform under the Player.")]
    public float platformDistanceCheck = 1.1f;
    public LayerMask platformLayer;

    private Collider2D col;
    private Collider2D platformColToIgnore;

    private float ignoreTimer = 0f;

    private void Awake() {
        col = GetComponent<Collider2D>();
    }

    private void Update() {
        if (ignoreTimer > 0f) {
            ignoreTimer -= Time.deltaTime;
        } else if (platformColToIgnore) {
            Physics2D.IgnoreCollision(col, platformColToIgnore, false);
            platformColToIgnore = null;
        }
        if (Input.GetAxisRaw("Vertical") < 0f) {
            CheckForPlatform();
        }
    }

    private void CheckForPlatform() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, platformDistanceCheck, platformLayer);
        if (hit) {
            if (platformColToIgnore) {
                Physics2D.IgnoreCollision(col, platformColToIgnore, false);
            }
            platformColToIgnore = hit.collider;
            Physics2D.IgnoreCollision(col, platformColToIgnore);
            ignoreTimer = disableCollisionTime;
        }
    }
}
