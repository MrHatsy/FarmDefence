using UnityEngine;

public class DistanceAttack : MonoBehaviour
{
    [SerializeField] private Transform attack;
    [SerializeField] private float duration = 10f; // how long are we spinning for
    [SerializeField] private float spinSpeed = 100f; // how FAST do we spin...duh.
    [SerializeField] private float strength = 10f; //Damage Strength

    private float timer;

    private Vector3 targetScale; // how long(length) the attack it gets
    private Vector3 currentScale;

    private Soldier soldier;

    private void Awake()
    {
        soldier = GetComponentInParent<Soldier>(); // get the soldier this attack is attached to

        targetScale = attack.localScale;    // target scale is what ever its set as in untiy as of opening the editor
        currentScale = Vector3.zero;       
        attack.localScale = Vector3.zero; // on game load, it is scaled to 0
    }

    void Update()
    {
        HandleAttack();
    }

    private void HandleAttack() // Attack Details
    {
        if (!soldier.isPossessed)
        {
            timer = 0f;

            currentScale = Vector3.zero;
            attack.localScale = currentScale; // When not possessed, size to 0.

            return;
        }

        
        timer += Time.deltaTime;  // start timer when possessed

        if (timer > duration)
        {
            currentScale = Vector3.zero;
            attack.localScale = currentScale;
            return;
        }

        
        attack.Rotate(0f, 0f, spinSpeed * Time.deltaTime); // spins the attack sprite

        
        currentScale = Vector3.Lerp(currentScale, targetScale, Time.deltaTime * 2); // naturally stops
        attack.localScale = currentScale; // size to 0.
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        //enemie?.TakeDamage(strength * Time.deltaTime);
    }
}