using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    private SpriteRenderer mySpriteRenderer;
    [SerializeField] private float currentSpeed = 5.0f;
    private Vector3 direction;
    private PlayerActions actions;
    private InputAction movementAction;
    private InputAction interactionAction;
    private InputAction pauseAction;
    public bool haunted;
    public bool attackActive;
    public bool movementEnabled;
    public static List<Soldier> nearbySoldiers = new List<Soldier>();
    public static List<Soldier> possessedSoldiers = new List<Soldier>(); // used to count active/haunted soldiers

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        actions = new PlayerActions();
        movementAction = actions.flying.movement;
        interactionAction = actions.flying.interaction;
        pauseAction = actions.flying.Pause;
        pauseAction.started += OnPause;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
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

        Debug.Log(possessedSoldiers.Count );
    }

    public void Move()
    {
        Vector2 input = movementAction.ReadValue<Vector2>();
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if(screenPos.x < 0 && input.x < 0)
        {
            input.x = 0;
        }

        else if(screenPos.x > Screen.width && input.x > 0)
        {
            input.x = 0;
        }
        if(screenPos.y < 0 && input.y < 0)
        {
            input.y = 0;
        }
        else if(screenPos.y > Screen.height && input.y > 0)
        {
            input.y = 0;
        }
        direction = new Vector3(input.x, input.y, 0f);
        if (Mathf.Abs(direction.normalized.x) > 0.5 )
        {
            if (direction.x > 0) //flip sprite depending on direction
            {
                mySpriteRenderer.flipX = false;
            }
            else
            {
                mySpriteRenderer.flipX = true;
            }
        }
        transform.Translate(direction * currentSpeed * Time.deltaTime, Space.World);
    }

    private void SoldierInteraction()
{
    if (!interactionAction.WasPressedThisFrame()) // if I didnt interact, ignore this.
        return;

    if (nearbySoldiers.Count == 0) // if there are no soldier near me, ignore this
        return;

    HauntSoldier(nearbySoldiers[0]); // haunt a solider
    Debug.Log("I pressed E to Haunt");
}

private void HauntSoldier(Soldier newSoldier)
{
    if (possessedSoldiers.Contains(newSoldier))
        return;

    if (possessedSoldiers.Count >= 2) // if ive haunted 2 soldiers
    {
        possessedSoldiers[0].isPossessed = false; // the first one i haunted deactivates
        possessedSoldiers.RemoveAt(0); // gets removed from my list
    }

    possessedSoldiers.Add(newSoldier); // add this new soldier into the list of possed ones

    newSoldier.Possess(); // this turns on the timer (lowkey only for the main attack)

    attackActive = true;
    transform.position = newSoldier.transform.position; // ghost snaps into center but can still move (just a temporary visual thing)
}

   private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.CompareTag("Soldier")) // if ghost collides with soldier
    {
        Soldier s = collision.GetComponent<Soldier>(); // the soldier i collided with is now my nearby one
        if (!nearbySoldiers.Contains(s))
            nearbySoldiers.Add(s);
    }
}

    private void OnTriggerExit2D(Collider2D collision)
{
    if (collision.CompareTag("Soldier")) // if ghost exits soldier collison
        {
        Soldier s = collision.GetComponent<Soldier>();
        nearbySoldiers.Remove(s); // i forget the previous nearby ghost
        }
    }

    private void OnPause(InputAction.CallbackContext context)
    {
        movementEnabled = !movementEnabled;
        if (movementEnabled)
        {
            movementAction.Enable();
        }
        else
        {
            movementAction.Disable();
        }
    }
}