using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    public ProjectileWeapon weapon;

    private void Update() {
        if (Input.GetButton("Fire1")) {
            weapon.HandleInput();
        }
    }
}
