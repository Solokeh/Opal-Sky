public class EnemyStats : Stats {
    public HealthUI ui;
    public int points;

    public override void Damage(int damage) {
        base.Damage(damage);
        ui.UpdateHealthBar(health, maxHealth);
    }

    public override void Heal(int heal) {
        base.Heal(heal);
        ui.UpdateHealthBar(health, maxHealth);
    }

    protected override void Kill() {
        base.Kill();
        Score.Points += points;
    }
}
