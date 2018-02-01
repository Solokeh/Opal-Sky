using UnityEngine;

public class PlayerStats : Stats {
    public PlayerJet jet;

    public GameObject gun;
    [HideInInspector]
    public SpriteRenderer sr;
    [HideInInspector]
    public Collider2D col;
    [HideInInspector]
    public Rigidbody2D rb;
    [HideInInspector]
    public PlayerMovement movement;
    [HideInInspector]
    public PlayerShoot shoot;

    private void Awake() {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<PlayerMovement>();
        shoot = GetComponent<PlayerShoot>();
    }

    private void Start() {
        Score.Points = 0;
    }

    public override void Damage(int damage) {
        base.Damage(damage);
        UI.UpdateHealthBar(health, maxHealth);
    }

    public override void Heal(int heal) {
        base.Heal(heal);
        UI.UpdateHealthBar(health, maxHealth);
    }

    protected override void Kill() {
        rb.gravityScale = 0;
        col.enabled = false;
        sr.enabled = false;
        health = maxHealth;
        UI.UpdateHealthBar(health, maxHealth);
        jet.Fuel = jet.MaxFuel;
        if (PlayerPrefs.GetInt("High Score", 0) < Score.Points) {
            PlayerPrefs.SetInt("High Score", Score.Points);
        }
        UI.ShowDeathMenu(true);
    }
}
