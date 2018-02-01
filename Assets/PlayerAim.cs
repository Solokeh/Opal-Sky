using UnityEngine;

public class PlayerAim : MonoBehaviour {
    public Transform objToAim;
    public float speed = 20f;
    private Camera cam;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private void Awake() {
        cam = Camera.main;
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        Vector2 objPos = objToAim.position;
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        sr.flipX = (mousePos.x < objPos.x) ? true : false;
        objToAim.right = Vector2.MoveTowards(objToAim.right, mousePos - objPos, speed * Time.deltaTime);
    }
}
