using UnityEngine;
using UnityEngine.UI;

// Only ONE of this object should exist!
public class UI : MonoBehaviour {
    public Image fuelBar;
    private static UI ui;

    private void Awake() {
        ui = this;
    }

    public void FuelBar(int fuel, int maxFuel) {
        float fFuel = fuel, fMaxFuel = maxFuel;
        fuelBar.fillAmount = fFuel / fMaxFuel;
    }

    public static void UpdateFuelBar(int fuel, int maxFuel) {
        ui.FuelBar(fuel, maxFuel);
    }
}
