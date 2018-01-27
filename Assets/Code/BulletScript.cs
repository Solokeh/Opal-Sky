using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    private GameObject author;
    public Transform debris;
    public float damage = 25f;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if(collision.gameObject != author)
        {
            Instantiate(debris, transform.position, transform.rotation);
            if (collision.gameObject.GetComponent<healthManager>())
            {
                collision.gameObject.GetComponent<healthManager>().CalcDamage(damage);
            }
        }
    }
}
