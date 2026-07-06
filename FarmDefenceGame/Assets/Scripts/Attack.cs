using UnityEngine;

public class Attack : MonoBehaviour
{ 
    [SerializeField] private Transform attack;
    //[SerializeField] private Vector3 targetScale = new Vector3(4f, 4f, 4f);
    //private float scaleSpeed = 0.03f;
    private float resetCooldown = 1.5f; 
    private float cooldownTimer = 0f;
    
    // private bool isResetting = false;
    private Vector3 maxScale = new Vector3(8f, 8f, 8f);

    //private PlayerMovement Player;
    private Soldier soldier;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
{
    //Player = FindFirstObjectByType<PlayerMovement>();
    soldier = GetComponentInParent<Soldier>();
    attack.localScale = Vector3.zero;
}
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AttackRadius();
    }

   private void AttackRadius()
{
    if (!soldier.isPossessed)
    {
        attack.localScale = Vector3.zero;
        return;
    }

    Vector3 nextScale = attack.localScale + Vector3.one * 0.008f;
    attack.localScale = Vector3.Min(nextScale, maxScale);

    if (nextScale.x >= maxScale.x)
    {
        attack.localScale = Vector3.zero;
    }
}
}