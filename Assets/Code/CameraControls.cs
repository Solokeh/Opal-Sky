using UnityEngine;

public class CameraControls : MonoBehaviour {
    public Transform target;

    private void LateUpdate() {
        if (target) {
            Vector2 targetPos = target.position;
            transform.position = new Vector3(targetPos.x, targetPos.y, -10f);
        }
    }
}
