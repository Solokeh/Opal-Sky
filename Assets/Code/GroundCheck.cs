using UnityEngine;

public abstract class GroundCheck : MonoBehaviour {
    [Tooltip("The distance of the raycast which checks for ground under the Player.")]
    public float groundDistanceCheck = 1.1f;
    public LayerMask groundLayer;

    protected bool CheckForGround() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundDistanceCheck, groundLayer);
        if (hit) {
            return (true);
        }
        return (false);
    }
}
