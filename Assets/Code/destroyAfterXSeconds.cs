using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAfterXSeconds : MonoBehaviour
{
    public float timeTillDestroy = 5f;

    void Start()
    {
        Invoke("DestroySelf", timeTillDestroy);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
