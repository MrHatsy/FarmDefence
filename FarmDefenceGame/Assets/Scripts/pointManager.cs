using UnityEngine;

public class PointManager : MonoBehaviour
{
    private int points;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addPoints(){
        points += 10;
    }
}
