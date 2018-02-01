using UnityEngine;
using UnityEngine.UI;

// Only ONE of this object should exist!
public class UI : MonoBehaviour {
    public Image healthBar, fuelBar;
    public Text score;
    private static UI ui;

    private void Awake() {
        ui = this;
    }

    public void HealthBar(int health, int maxHealth) {
        float fHealth = health, fMaxHealth = maxHealth;
        healthBar.fillAmount = fHealth / fMaxHealth;
    }

    public static void UpdateHealthBar(int health, int maxHealth) {
        ui.HealthBar(health, maxHealth);
    }

    public void FuelBar(int fuel, int maxFuel) {
        float fFuel = fuel, fMaxFuel = maxFuel;
        fuelBar.fillAmount = fFuel / fMaxFuel;
    }

    public static void UpdateFuelBar(int fuel, int maxFuel) {
        ui.FuelBar(fuel, maxFuel);
    }

    public void Score(int score) {
        this.score.text = "Score: " + score;
    }

    public static void UpdateScore(int score) {
        ui.Score(score);
    }
}
