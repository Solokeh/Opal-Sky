public class PlayerStats : Stats {

    public override void Damage(int damage) {
        base.Damage(damage);
        UI.UpdateHealthBar(health, maxHealth);
    }

    public override void Heal(int heal) {
        base.Heal(heal);
        UI.UpdateHealthBar(health, maxHealth);
    }
}
