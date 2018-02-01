using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AI_Alien : GroundCheck {
    public Stats stats;
    public Vector2 target;
    public float viewDistance = 10f;
    [Tooltip("The amount of distance the Target has to be away from this object to stop moving.")]
    public float offsetDistance = 1f;
    [Tooltip("The amount of height the Target has to be higher than this object for it to jump.")]
    public float jumpOffset = 1.1f;
    public LayerMask playerLayer;
    public int damage = 10;
    [Tooltip("The time (in seconds) before the next attack can be made.")]
    public float attackDelay = 0.2f;

    private Rigidbody2D rb;
    private float attackTimer = 0f;
    private bool attacking = false;
    private Stats targetStats;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        target = transform.position;
    }

    private void Update() {
        if (attackTimer > 0f) {
            attackTimer -= Time.deltaTime;
        } else if (attacking) {
            Attack(targetStats);
        }
    }

    private void FixedUpdate() {
        Collider2D hitCol = Physics2D.OverlapCircle(transform.position, viewDistance, playerLayer);
        if (hitCol) {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, hitCol.transform.position - transform.position);
            if ((hit) && (hit.collider.CompareTag("Player"))) {
                Vector2 pos = transform.position;
                target = hit.transform.position;
            }
        }
        Movement();
    }

    private void Movement() {
        float horizontalDir = 0f;
        Vector2 pos = transform.position;
        if ((!attacking) && (Mathf.Abs(target.x - pos.x) > offsetDistance)) {
            Vector2 dir = target - pos;
            if (dir.x > 0f) {
                horizontalDir = 1f;
            } else if (dir.x < 0f) {
                horizontalDir = -1f;
            }
        }
        if (((target.y - pos.y) > jumpOffset) && (CheckForGround())) {
            rb.AddForce(Vector2.up * stats.JumpForce, ForceMode2D.Impulse);
        }
        rb.velocity = new Vector2(horizontalDir * stats.Speed, rb.velocity.y);
    }

    private void Attack(Stats stats) {
        stats.Damage(damage);
        attackTimer = attackDelay;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Player")) {
            attacking = true;
            targetStats = collision.collider.GetComponent<Stats>();
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.collider.CompareTag("Player")) {
            attacking = false;
            targetStats = null;
        }
    }
}
