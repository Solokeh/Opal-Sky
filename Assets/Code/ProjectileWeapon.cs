using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{

    public Rigidbody2D bullet;
    public float bulletVel = 50f;
    public bool canFire = true;
    public float fireRate = 0.2f;
    private new AudioSource audio;
    public AudioClip magnumWeaponFire;
    public float timeUntilFire;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void HandleInput()
    {
        if (canFire)
        {
            canFire = false;
            audio.PlayOneShot(magnumWeaponFire);
            Invoke("FireProjectile", timeUntilFire);
        }
    }

    public void FireProjectile()
    {

        Rigidbody2D clone = Instantiate(bullet, transform.position + transform.right * 2f, transform.rotation) as Rigidbody2D;

        clone.velocity = (transform.right * bulletVel);
        Invoke("ResetCanFire", fireRate);
    }

    void ResetCanFire()
    {
        canFire = true;
    }
}
