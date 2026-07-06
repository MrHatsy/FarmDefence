using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Media;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float currentSpeed = 5.0f;
    private Vector3 direction;
    private PlayerActions actions;
    private InputAction movementAction;
    private InputAction interactionAction;
    public bool haunted;

    public bool attackActive;
    //private Soldier nearbySoldier;
    private List<Soldier> nearbySoldiers = new List<Soldier>();
    private float hauntTimer;
    

    private List<Soldier> possessedSoldiers = new List<Soldier>();

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
        //HandleHauntTimer();
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

    if (nearbySoldiers.Count == 0)
        return;

     HauntSoldier(nearbySoldiers[0]);
    Debug.Log("I pressed E to Haunt");
}

private void HauntSoldier(Soldier newSoldier)
{
    if (possessedSoldiers.Contains(newSoldier))
        return;

    if (possessedSoldiers.Count >= 2)
    {
        possessedSoldiers[0].isPossessed = false;
        possessedSoldiers.RemoveAt(0);
    }

    possessedSoldiers.Add(newSoldier);

    newSoldier.Possess(); 

    attackActive = true;
    transform.position = newSoldier.transform.position;
}

    // private void ReleaseSoldier()
    // {
    //     haunted = false;
    //     if (nearbySoldier != null)
    //     nearbySoldier.isPossessed = false;
    // }

   private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.CompareTag("Soldier"))
    {
        Soldier s = collision.GetComponent<Soldier>();
        if (!nearbySoldiers.Contains(s))
            nearbySoldiers.Add(s);
    }
}

    private void OnTriggerExit2D(Collider2D collision)
{
    if (collision.CompareTag("Soldier"))
    {
        Soldier s = collision.GetComponent<Soldier>();
        nearbySoldiers.Remove(s);
    }
}

//     private void HandleHauntTimer()
// {
//     if (possessedSoldiers.Count == 0)
//     return;

//     hauntTimer -= Time.deltaTime;
//     Debug.Log("Haunt timer: " + hauntTimer);

//     if (hauntTimer <= 0f)
// {
//     attackActive = false;

//     for (int i = 0; i < possessedSoldiers.Count; i++)
//     {
//         possessedSoldiers[i].isPossessed = false;
//     }

//     possessedSoldiers.Clear();

//     haunted = false;
// }
// }


    private void CheckCollision()
    {
        // do somehting     
    }
}
