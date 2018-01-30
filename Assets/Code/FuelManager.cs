using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelManager : MonoBehaviour {
    [HideInInspector]
    public sideScrollerController controller;
    public float jetForce = 100f;
    [SerializeField]
    private int fuel = 100;
    [SerializeField]
    private int maxFuel = 100;

    private bool readFlyInput = false;
    public bool isFlying = false;

    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Jet() {
        if (Input.GetButton("Jump")) {
            if ((readFlyInput) && (!controller.canJump)) {
                isFlying = true;
                Fuel--;
                controller.positionToMoveTo += (Vector2.up * jetForce);
            }
        } else if (Input.GetButtonUp("Jump")) {
            readFlyInput = true;
            isFlying = false;
        } else if (controller.canJump) {
            readFlyInput = false;
            isFlying = false;
        }
    }

    public int Fuel {
        get {
            return (fuel);
        }
        set {
            fuel = value;
            CheckFuel();
        }
    }

    public int MaxFuel {
        get {
            return (maxFuel);
        }
    }

    private void CheckFuel() {
        if (fuel < 0) {
            fuel = 0;
        } else if (fuel > maxFuel) {
            fuel = maxFuel;
        }
    }
}
