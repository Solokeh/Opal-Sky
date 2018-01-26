using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinSpawner : MonoBehaviour {

    public float speed = 0.1f;
    public float xDistMax = 22;
    public bool isGoingRight = true;
    public Rigidbody2D coin;

	void Start ()
    {
        Invoke("SpawnCoin", 0.00f);
	}
	
	void Update ()
    {
        SwitchDirections();
	}

    void SwitchDirections()
    {
        if(isGoingRight == true)
        {
            transform.position = transform.position + transform.right * speed;
            if(transform.position.x > xDistMax)
            {
                isGoingRight = false;
            }
        }
        else
        {
            transform.position = transform.position + transform.right * -speed;
            if (transform.position.x < -xDistMax)
            {
                isGoingRight = true;
            }
        }
    }

    void SpawnCoin()
    {
        Instantiate(coin, transform.position, transform.rotation);
        Invoke("SpawnCoin", Random.Range(0.1f, 0.5f));
    }
}
