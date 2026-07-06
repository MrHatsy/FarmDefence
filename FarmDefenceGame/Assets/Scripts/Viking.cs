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

    }

    // Update is called once per frame
    void Update()
    {
        //move toward target
        //add variance to the path by making the target randomly move a bit
        Vector3 targetWithVariance = target.transform.position + new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0);
        direction = (targetWithVariance - this.transform.position);
        direction.z = 0;
        direction = direction.normalized;
        transform.Translate(direction * speed * Time.deltaTime);

        //if hp <=0 , i am dead
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }

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
    
    void OnTriggereEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 7 && other.gameObject == target.gameObject)
        {
            target.addViking();
        }
    }
}
