using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthManager : MonoBehaviour {

    public float healthValue = 100f;
    public bool isDead = false;

	void Start ()
    {
		
	}

    private void Update()
    {
        if(healthValue <= 0)
        {
            healthValue = 0;
            isDead = true;
        }
        else
        {
            isDead = false;
        }
    }

   public void CalcDamage(float damage)
    {
        healthValue -= damage;
    }
}
