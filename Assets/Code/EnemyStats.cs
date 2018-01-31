public class EnemyStats : Stats {
    public HealthUI ui;

    public override void Damage(int damage) {
        base.Damage(damage);
        ui.UpdateHealthBar(health, maxHealth);
    }

    public override void Heal(int heal) {
        base.Heal(heal);
        ui.UpdateHealthBar(health, maxHealth);
    }
}
