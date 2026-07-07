 using UnityEngine;

public class CapsuleAttack : MonoBehaviour
{
    [SerializeField] private GameObject capsulePrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float force = 1f;
    [SerializeField] private float repeatDelay = 3f;
    [SerializeField] private float duration = 10f;
    [SerializeField] private float strength = 10f; //Damage Strength
    private Soldier soldier;

    private float attackTimer;
    private float repeatTimer;

    private bool active;

    private readonly Vector2[] directions = new Vector2[] //bullets directions
    {
        new Vector2(-0.5f, 1f), // left 
        new Vector2(0f, 1f), // center
        new Vector2(0.5f, 1f) // right
    };

    void Awake()
    {
        soldier = GetComponentInParent<Soldier>();
    }

    void Update()
    {
        if (!soldier.isPossessed)
        {
            active = false;
            attackTimer = 0f;
            repeatTimer = 0f;
            return;
        }

        if (!active)
        {
            active = true;
            attackTimer = 0f;
            repeatTimer = 0f;
            FireCapsules(); //  fires bullets...
        }

        RunAttack();
    }

    private void RunAttack()
    {
        attackTimer += Time.deltaTime;
        repeatTimer += Time.deltaTime;

        if (attackTimer >= duration)
        {
            active = false;
            attackTimer = 0f;
            repeatTimer = 0f;
            if (PlayerMovement.possessedSoldiers.Count > 0)
            {
                PlayerMovement.possessedSoldiers.Remove(soldier);
            }
            return;
        }

        if (repeatTimer >= repeatDelay) 
        {
            FireCapsules();
            repeatTimer = 0f; // repeat burst every 3 seconds
        }
    }

    private void FireCapsules()
    {
        for (int i = 0; i < 3; i++) // three bullets
        {
            GameObject c = Instantiate(capsulePrefab, spawnPoint.position, Quaternion.identity); // spawns bulllets

            Destroy(c, 3f);

            Rigidbody2D rb = c.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 dir = directions[i].normalized;
                rb.linearVelocity = dir * force; // move bullets in these directions with this power
            }
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        //enemie?.TakeDamage(strength * Time.deltaTime);
    }

}