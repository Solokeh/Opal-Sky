using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    /*public ProjectileWeapon gun;
    public float gunSmooth = 0.1f;
    public GameObject target;
    public bool canFire = false;
    public float ROF = 0.00f;

    // Use this for initialization
    void Start()
    {
        Invoke("FireWeapon", 0.00f);
    }

    // Update is called once per frame
    void Update()
    {
        ControlWeaponRotationAndPosition();
        ControlIfCanFire();
    }

    void ControlIfCanFire()
    {
        if (target)
        {
            if (!target.GetComponent<healthManager>().isDead)
            {
                canFire = true;
            }
            else
            {
                canFire = false;
            }
        }
        else
        {
            canFire = false;
        }
    }

    void FireWeapon()
    {
        if (canFire)
        {
            gun.HandleInput();
        }

        Invoke("FireWeapon", Random.Range(ROF+0.2f, ROF+0.4f));
    }

    void ControlWeaponRotationAndPosition()
    {
        if (target)
        {
            gun.transform.position = transform.position + new Vector3(0, 1, 0);

            Vector3 aimPoint = target.transform.position;

            float AngleRad = Mathf.Atan2(aimPoint.y - gun.transform.position.y, aimPoint.x - gun.transform.position.x);
            float angle = (180 / Mathf.PI) * AngleRad;

            gun.transform.rotation = Quaternion.Lerp(gun.transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), gunSmooth);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            target = collision.gameObject;
        }
    }*/
}
