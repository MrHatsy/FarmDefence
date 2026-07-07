using UnityEngine;

public class Viking : MonoBehaviour
{
    //params (vars that are set)
    [SerializeField] private int hp;
    [SerializeField] private float speed;

    //states (vars that change)
    private UnityEngine.Vector3 direction;
    [SerializeField] private FarmNode target;


    void Start()
    {
        speed *= Random.Range(0.8f, 1.5f);
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

    }

    void movement()
    {
        Vector3 targetWithVariance = target.transform.position + new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), 0);
        direction = (targetWithVariance - this.transform.position);
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
                target = target.NextFarmNode;
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
}
