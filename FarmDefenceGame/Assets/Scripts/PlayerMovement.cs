using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float currentSpeed = 5.0f;
    private Vector3 direction;
    private PlayerActions actions;
    private InputAction movementAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        actions = new PlayerActions();
        movementAction = actions.flying.movement;
    }

     void OnEnable()
    {
        movementAction.Enable();
    }

     void OnDisable()
    {
        movementAction.Disable();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        Vector2 input = movementAction.ReadValue<Vector2>();
          direction = new Vector3(input.x, input.y, 0f);
        transform.Translate(direction * currentSpeed * Time.deltaTime, Space.World);
    }
}
