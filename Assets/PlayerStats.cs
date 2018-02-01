public class PlayerStats : Stats {
    public PlayerJet jet;

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
        health = maxHealth;
        UI.UpdateHealthBar(health, maxHealth);
        jet.Fuel = jet.MaxFuel;
        Score.Points = 0;
        ShipSetter.GenerateShip();
    }
}
