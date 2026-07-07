using UnityEngine;

public class PointManager : MonoBehaviour
{
    //constants
    [SerializeField] private int pointMilestone;
    private SpriteRenderer mySpriteRenderer;
    [SerializeField] private Sprite sprite1;
    [SerializeField] private Sprite sprite2;
    [SerializeField] private Sprite sprite3;
    [SerializeField] private Sprite sprite4;

    [SerializeField] private GameObject WinPanel;

    //changings
    private int points;
    private static int progessState = 1;

    public int ProgessState
    {
        get
        {
            return progessState;
        }
    }

    public int Points
    {
        get
        {
            return points;
        }
    }

    void Start()
    {
        points = 0;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        updateSprite();

        // Debug.Log("Points: " + points +", Milestone: " + pointMilestone);

        if (points >= pointMilestone * progessState)
        {
            progessState++;
        }

        if (progessState >= 5)
        {
            //TODO
            WinPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void addPoints()
    {
        points += 1;
    }
    
    void updateSprite()
    {

        if ( progessState == 1)
        {
            mySpriteRenderer.sprite = sprite1;
        }
        if ( progessState == 2)
        {
            mySpriteRenderer.sprite = sprite2;
        }
        if ( progessState == 3)
        {
            mySpriteRenderer.sprite = sprite3;
        }
        if ( progessState == 4)
        {
            mySpriteRenderer.sprite = sprite4;
        }
        
    }
}
