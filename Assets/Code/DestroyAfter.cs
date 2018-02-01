using UnityEngine;

public class DestroyAfter : MonoBehaviour {
    public float destroyDelay = 5f;

    private void Start() {
        Destroy(gameObject, destroyDelay);
    }
}
