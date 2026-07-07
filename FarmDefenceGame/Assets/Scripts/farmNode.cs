using UnityEngine;

public class FarmNode : MonoBehaviour
{
    [SerializeField] private float timerMax;
    private float timer; //for scoring and taking damage
    [SerializeField] private FarmNode nextNode;
    [SerializeField] private bool verticalFarm;
    private PointManager myPointManager;
    private SpriteRenderer mySpriteRenderer;
    [SerializeField] private int hpMax;

    //states
    private int hp;
    private int vikingCount;
    [SerializeField] private bool alive;

    //sprites
    [SerializeField] private Sprite sprite1;
    [SerializeField] private Sprite sprite2;
    [SerializeField] private Sprite sprite3;
    [SerializeField] private Sprite sprite4;


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
        hp = hpMax;
        myPointManager = FindFirstObjectByType<PointManager>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        updateSprite();
    }

    // Update is called once per frame
    void Update()
    {
        updateSprite();
        if (alive == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                //gain points
                myPointManager.addPoints();

                //take damage
                takeDamage();

                //reset timer
                timer = timerMax;

                //update sprite

            }
        }
    }

    void takeDamage()
    {
        if (vikingCount > 0)
        {
            hp -= (vikingCount + 1) / 2; //every two vikings does an extra damage
            Debug.Log("I'm hurt! My health is: " + hp);
        }
        //die if dead
        if (hp <= 0)
        {
            alive = false;
            // mySpriteRenderer.color = Color.red;
        }
    }

    FarmNode getNextNode()
    {
        return nextNode;
    }

    void updateSprite()
    {

        if ((float)hp <= (float)hpMax * 0f)
        {
            mySpriteRenderer.sprite = sprite4;
            mySpriteRenderer.color = Color.gray;
        }
        else if ((float)hp <= (float)hpMax * 0.1f)
        {
            mySpriteRenderer.sprite = sprite4;
        }
        else if ((float)hp <= (float)hpMax * 0.4f)
        {
            mySpriteRenderer.sprite = sprite3;
        }
        else if ((float)hp <= (float)hpMax * 0.7f)
        {
            mySpriteRenderer.sprite = sprite2;
        }
        else
        {
            mySpriteRenderer.sprite = sprite1;
        }
    }
}
