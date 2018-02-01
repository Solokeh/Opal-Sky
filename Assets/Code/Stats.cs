using UnityEngine;

public class Stats : MonoBehaviour {
    [SerializeField]
    protected int health = 100;
    [SerializeField]
    protected int maxHealth = 100;
    [SerializeField]
    protected float speed = 10f;
    [SerializeField]
    protected float jumpForce = 5f;

    public virtual void Damage(int damage) {
        health -= damage;
        CheckHealth();
    }

    public virtual void Heal(int heal) {
        health += heal;
        CheckHealth();
    }

    public int Health {
        get {
            return (health);
        }
    }

    public int MaxHealth {
        get {
            return (maxHealth);
        }
    }

    public float Speed {
        get {
            return (speed);
        }
        set {
            speed = value;
        }
    }

    public float JumpForce {
        get {
            return (jumpForce);
        }
        set {
            jumpForce = value;
        }
    }

    protected void CheckHealth() {
        if (health <= 0) {
            Kill();
        } else if (health > maxHealth) {
            health = maxHealth;
        }
    }

    protected virtual void Kill() {
        Destroy(gameObject);
    }
}
