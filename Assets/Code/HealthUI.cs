using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {
    public Image healthBar;

    public void UpdateHealthBar(int health, int maxHealth) {
        float fHealth = health, fMaxHealth = maxHealth;
        healthBar.fillAmount = fHealth / fMaxHealth;
    }
}
