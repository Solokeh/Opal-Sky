using UnityEngine;
using UnityEngine.UI;

// Only ONE of this object should exist!
public class UI : MonoBehaviour {
    public PlayerStats stats;
    public GameObject deathMenu;
    public Image healthBar, fuelBar;
    public Text score, endScore, highScore;
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

    public void ScoreText(int score) {
        this.score.text = "Score: " + score;
    }

    public static void UpdateScore(int score) {
        ui.ScoreText(score);
    }

    public void DeathMenu(bool show) {
        deathMenu.SetActive(show);
        if (show) {
            stats.rb.gravityScale = 0f;
            stats.rb.velocity = Vector2.zero;
        } else {
            stats.rb.gravityScale = 1f;
        }
        stats.shoot.enabled = !show;
        stats.movement.enabled = !show;
        stats.gun.SetActive(!show);
        stats.col.enabled = !show;
        stats.sr.enabled = !show;
        score.enabled = !show;
        fuelBar.transform.parent.gameObject.SetActive(!show);
        healthBar.transform.parent.gameObject.SetActive(!show);
        endScore.text = "Score: " + Score.Points;
        highScore.text = "High Score: " + PlayerPrefs.GetInt("High Score", 0);
        Score.Points = 0;
    }

    public static void ShowDeathMenu(bool show) {
        ui.DeathMenu(show);
    }

    public void RestartGame() {
        DeathMenu(false);
        ShipSetter.GenerateShip();
    }
}
