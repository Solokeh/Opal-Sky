using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformScript : MonoBehaviour {

    private BoxCollider2D box;
    public float timeCanPassThrough = 1f;

	void Start ()
    {
        box = GetComponent<BoxCollider2D>();	
	}
	
	void Update ()
    {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            box.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Invoke("ReEnableCollider", timeCanPassThrough);
        }
    }

    void ReEnableCollider()
    {
        box.enabled = true;
    }
}
