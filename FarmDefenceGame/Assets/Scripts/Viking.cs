using UnityEngine;

public class Viking : MonoBehaviour
{
    //params (vars that are set)

    [SerializeField] private float speed;
    private PointManager myPointManager;
    private SpriteRenderer mySpriteRenderer;

    //states (vars that change)
    private UnityEngine.Vector3 direction;
    private int hp;
    [SerializeField] private FarmNode target;
    private Vector3 targetPos; // has some randomness so they arent so robotic

    void Start()
    {
        speed *= Random.Range(0.8f, 1.5f);
        setTarget(target);
        myPointManager = FindFirstObjectByType<PointManager>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //move toward target
        //add variance to the path by making the target randomly move a bit
        movement();

        //if hp <=0 , i am dead
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }

        //if we win, all vikings die
        if (myPointManager.ProgessState >= 5)
        {
            Destroy(this.gameObject);
        }
    }

    void movement()
    {
        Vector3 targetWithVariance = targetPos + new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0);
        //makes them jitter on their target
        direction = (targetWithVariance - this.transform.position);

        if (Mathf.Abs(direction.normalized.x) > 0.5 && direction.magnitude > 4)
        {
            if (direction.x > 0) //flip sprite depending on direction
            {
                mySpriteRenderer.flipX = true;
            }
            else
            {
                mySpriteRenderer.flipX = false;
            }
        }

        direction.z = 0;
        direction = direction.normalized;
        
        
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == 7 && other.gameObject == target.gameObject)
        {
            if (target.AmIAlive == false)
            {
                //if this farm is dead, move to the next one
                target.minusViking();
                setTarget(target.NextFarmNode);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 7 && other.gameObject == target.gameObject)
        {
            target.addViking();
        }

        takeDamage(other);
    }

    void takeDamage(Collider2D other)
    {

        //take damage when colliding with a projectile
        if (other.gameObject.layer == 10)
        {
            hp--;
        }
    }

    public void setTarget(FarmNode newTarget)
    {
        target = newTarget;
        targetPos = target.transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
    }

    public void setHP(int spawnHP)
    {
        hp = spawnHP;
    }

}
