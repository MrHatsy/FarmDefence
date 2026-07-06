using UnityEngine;

public class Attack : MonoBehaviour
{ 
    [SerializeField] private Transform attack;
    [SerializeField] private Vector3 targetScale = new Vector3(2f, 2f, 2f);
    private float scaleSpeed = 0.03f;
    private Vector3 maxScale = new Vector3(5f, 5f, 5f);
    private PlayerMovement Player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        Player = FindFirstObjectByType<PlayerMovement>();
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
        if (!Player.haunted)
        {
            return;
        }
        Vector3 nextScale = transform.localScale + new Vector3(0.01f, 0.01f, 0.01f);
        transform.localScale = Vector3.Min(nextScale, maxScale);
    }
}