using UnityEngine;

public class FarmNode : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private bool alive;
    [SerializeField] private FarmNode nextNode;
    private object myPointManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myPointManager = FindFirstObjectByType(PointManager);
    }

    // Update is called once per frame
    void Update()
    {
        if (alive == true)
        {
            //gain points
            myPointManager.addPoints();

            //take damage

        }
    }

    FarmNode getNextNode()
    {
        return nextNode;
    }
}
