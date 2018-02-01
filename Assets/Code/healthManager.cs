using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthManager : MonoBehaviour {

    [SerializeField]
    private float healthValue = 100f;
    private bool isDead = false;

   public void CalcDamage(float damage)
    {
        healthValue -= damage;
        if (healthValue <= 0)
        {
            healthValue = 0;
            isDead = true;
        }
        else
        {
            isDead = false;
        }
    }

    public bool IsDead
    {
        get
        {
            return (isDead);
        }
    }
}
