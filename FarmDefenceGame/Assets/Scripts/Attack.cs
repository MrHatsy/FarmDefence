using UnityEngine;

public class Attack : MonoBehaviour
{ 
    [SerializeField] private Transform attack;
    [SerializeField] private Vector3 targetScale = new Vector3(2f, 2f, 2f);
    private float scaleSpeed = 0.03f;
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
        if (!Player.haunted)
        {
            return;
        }
        transform.localScale = transform.localScale + new Vector3(0.002f, 0.002f, 0.002f);
    }
}
