using UnityEngine;

public class VikingSpawner : MonoBehaviour
{
    //params (constants)
    [SerializeField] private float spawnRateDefault;
    [SerializeField] private FarmNode target;
    [SerializeField] private GameObject vikingPrefab;
    private Transform myPosition;
    private PointManager myPointManager;
    [SerializeField] private int vikingHPDefault;

    //states (things that change)
    private float spawnRateCurr;
    private float timer;
    private int vikingHP;


    void Start()
    {
        spawnRateCurr = spawnRateDefault;
        timer = spawnRateCurr;
        myPosition = this.gameObject.GetComponent<Transform>();
        myPointManager = FindFirstObjectByType<PointManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        Debug.Log(timer);
        if (timer <= 0)
        {
            //make a viking
            GameObject newViking = Instantiate(
                vikingPrefab,
                myPosition.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0),
                Quaternion.identity);
            newViking.GetComponent<Viking>().setTarget(target);
            newViking.GetComponent<Viking>().setHP(vikingHP);
            timer = spawnRateCurr * Random.Range(0.9f, 1.2f);
        }


        //difficulty scaling
        spawnRateCurr = spawnRateDefault - myPointManager.ProgessState; //enemies will spawn faster
        vikingHP = vikingHPDefault * ( (myPointManager.ProgessState + 1) / 2 );

        //stop spawning if we win
        if (myPointManager.ProgessState >= 5)
        {
            Destroy(this.gameObject);
        }
        
    }
}
