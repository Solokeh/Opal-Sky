﻿using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{
    public Collider2D player;
    public Rigidbody2D bullet;
    public float bulletVel = 50f;
    public bool canFire = true;
    public float fireRate = 0.2f;
    private new AudioSource audio;
    public AudioClip magnumWeaponFire;
    public float timeUntilFire;
    [Tooltip("Where the bullet is instantiated. Smaller value will make the bullet spawn closer to the gun.")]
    public float bulletStartOffset;

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
        Rigidbody2D clone = Instantiate(bullet, transform.position + (transform.right * bulletStartOffset), transform.rotation, ShipGenerator.Ship.transform) as Rigidbody2D;
        Physics2D.IgnoreCollision(player, clone.GetComponent<Collider2D>());
        clone.velocity = (transform.right * bulletVel);
        Invoke("ResetCanFire", fireRate);
    }

    void ResetCanFire()
    {
        canFire = true;
    }
}
