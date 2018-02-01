using UnityEngine;

public class Point : MonoBehaviour {
    public int points;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            Score.Points += points;
            Destroy(gameObject);
        }
    }
}
