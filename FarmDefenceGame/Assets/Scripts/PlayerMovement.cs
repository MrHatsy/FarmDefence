using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Media;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float currentSpeed = 5.0f;
    private Vector3 direction;
    private PlayerActions actions;
    private InputAction movementAction;
    private InputAction interactionAction;
    private bool active;
    private Soldier nearbySoldier;
    //[SerializeField] private Collider2D playerCollider;
    //[SerializeField] private Collider2D soldierCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        actions = new PlayerActions();
        movementAction = actions.flying.movement;
        interactionAction = actions.flying.interaction;
    }

     void OnEnable()
    {
        movementAction.Enable();
        interactionAction.Enable();
    }

     void OnDisable()
    {
        movementAction.Disable();
        interactionAction.Disable();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        SoldierInteraction();
        Move();
    }

    public void Move()
    {
        Vector2 input = movementAction.ReadValue<Vector2>();
        direction = new Vector3(input.x, input.y, 0f);
        transform.Translate(direction * currentSpeed * Time.deltaTime, Space.World);
    }

    private void SoldierInteraction()
    {
        if (!interactionAction.WasPressedThisFrame())
            return;
    
        if (active)
        {
            ReleaseSoldier();
            Debug.Log("I pressed E to release");
        }
        else if(nearbySoldier != null)
        {
            HauntSoldier();
            Debug.Log("I pressed E to Haunt!");
        }
    }

    private void HauntSoldier()
    {
        currentSpeed = 0;
        active = true;
        transform.position = nearbySoldier.transform.position;
    }

    private void ReleaseSoldier()
    {
        active = false;
        currentSpeed = 10;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Soldier"))
        nearbySoldier = collision.GetComponent<Soldier>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Soldier"))
        {
            if (nearbySoldier != null && collision.GetComponent<Soldier>() == nearbySoldier)
            {
                nearbySoldier = null;
            }
        }
            
    }


    private void CheckCollision()
    {
        // do somehting     
    }
}
