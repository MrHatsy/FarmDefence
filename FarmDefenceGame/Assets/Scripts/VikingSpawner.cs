using UnityEngine;

public class VikingSpawner : MonoBehaviour
{
    //params (constants)
    [SerializeField] private float spawnRateDefault;
    [SerializeField] private FarmNode target;
    [SerializeField] private GameObject vikingPrefab;
    private Transform myPosition;
    private PointManager myPointManager;

    //states (things that change)
    private float spawnRateCurr;
    private float timer;


    void Start()
    {
        spawnRateCurr = spawnRateDefault;
        timer = spawnRateCurr;
        myPosition = this.gameObject.GetComponent<Transform>();
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
            timer = spawnRateCurr;
        }
    }
}
