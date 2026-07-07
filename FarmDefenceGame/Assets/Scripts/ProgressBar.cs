using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    private PointManager myPointManager;
    private SpriteRenderer mySpriteRenderer;
    [SerializeField] private Sprite sprite1;
    [SerializeField] private Sprite sprite2;
    [SerializeField] private Sprite sprite3;
    [SerializeField] private Sprite sprite4;
    [SerializeField] private Sprite sprite5;

    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myPointManager = FindFirstObjectByType<PointManager>();
    }

    // Update is called once per frame
    void Update()
    {
        updateSprite();
    }

    void updateSprite()
    {

        if (myPointManager.ProgessState == 1)
        {
            mySpriteRenderer.sprite = sprite1;
        }
        if (myPointManager.ProgessState == 2)
        {
            mySpriteRenderer.sprite = sprite2;
        }
        if (myPointManager.ProgessState == 3)
        {
            mySpriteRenderer.sprite = sprite3;
        }
        if (myPointManager.ProgessState == 4)
        {
            mySpriteRenderer.sprite = sprite4;
        }
        if ( myPointManager.ProgessState == 5)
        {
            mySpriteRenderer.sprite = sprite5;
        }
        
    }
}
