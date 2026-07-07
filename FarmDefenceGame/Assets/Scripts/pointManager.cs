using UnityEngine;

public class PointManager : MonoBehaviour
{
    //constants
    [SerializeField] private int pointMilestone; 

    //changings
    private int points;
    private int progessState = 1;

    public int ProgessState
    {
        get
        {
            return progessState;
        }
    }

    void Start()
    {
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Points: " + points);

        if (points >= pointMilestone * progessState)
        {
            progessState++;
        }

        if (progessState >= 4)
        {
            //TODO
            //WIN//WIN//WIN//WIN//WIN//WIN//WIN//WIN//WIN//WIN//WIN//WIN//WIN//WIN
            //WIN//WIN//WIN//WIN//WIN//WIN//WIN//WIN//WIN//WIN//WIN//WIN//WIN//WIN
            //WIN
        }
    }

    public void addPoints(){
        points += 10;
    }
}
