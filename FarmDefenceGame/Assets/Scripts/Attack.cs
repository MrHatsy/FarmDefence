using UnityEngine;

public class Attack : MonoBehaviour
{ 
    [SerializeField] private Transform attack;

    private Vector3 maxScale = new Vector3(32f, 32f, 32f); // max size of attack, can be changed :)
    private Soldier soldier;

    // [SerializeField] private float strength = 10f; //Damage Strength

    private void Awake()
{
    soldier = GetComponentInParent<Soldier>(); // when game starts get the soliders that is the parent of the main attack
    attack.localScale = Vector3.zero; // make it zero so player cant see
}

// Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AttackRadius();
    }

   private void AttackRadius() // main attack details
{
    if (!soldier.isPossessed)
        {
            attack.localScale = Vector3.zero; // if NOT possessed, make attack SUPER SUPER small
            return;
        }

    Vector3 nextScale = attack.localScale + Vector3.one * 0.02f; // gradually grow the attack, last condition chnages speed)
    attack.localScale = Vector3.Min(nextScale, maxScale);

    if (nextScale.x >= maxScale.x) // if the attack is at its max size
        {
            attack.localScale = Vector3.zero; // go back to zero
        }
    }

 void OnTriggerStay2D(Collider2D collider)
    {
        //enemie?.TakeDamage(strength * Time.deltaTime);
    }
}
