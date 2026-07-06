using UnityEngine;

public class FarmNode : MonoBehaviour
{
    [SerializeField] private float timerMax;
    private float timer; //for scoring and taking damage
    [SerializeField] private FarmNode nextNode;
    private PointManager myPointManager;

    //states
    [SerializeField] private int hp;
    private int vikingCount;
    [SerializeField] private bool alive;


    //properties
    public FarmNode NextFarmNode
    {
        get
        {
            return nextNode;
        }
    }

    public bool AmIAlive
    {
        get
        {
            return alive;
        }
    }

    public void addViking()
    {
        vikingCount++;
        // Debug.Log("I gained a Viking! Now I have: " + vikingCount);
    }

    public void minusViking()
    {
        vikingCount--;
        // Debug.Log("I lost a Viking... Now I have: " + vikingCount);
        if (vikingCount > 0)
        {
            vikingCount = 0;
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myPointManager = FindFirstObjectByType<PointManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alive == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                //gain points
                myPointManager.addPoints();

                //take damage
                if (vikingCount > 0)
                {
                    hp -= 1;
                    Debug.Log("I'm hurt! My health is: " + hp);
                }
                //die if dead
                if (hp <= 0)
                {
                    alive = false;
                    this.SpriteRenderer.color(200, 100, 100);
                }

                //reset timer
                timer = timerMax;
            }            
        }
    }

    FarmNode getNextNode()
    {
        return nextNode;
    }
}
