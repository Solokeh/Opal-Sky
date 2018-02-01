using UnityEngine;

public class BulletScript : MonoBehaviour {

    public Transform debris;
    public int damage = 25;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(debris, transform.position, transform.rotation, ShipGenerator.Ship.transform);
        Stats stats = collision.gameObject.GetComponent<Stats>();
        if (stats)
        {
            stats.Damage(damage);
            Destroy(gameObject);
        }
    }
}
