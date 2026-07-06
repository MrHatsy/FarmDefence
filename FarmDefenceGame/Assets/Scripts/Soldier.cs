using UnityEngine;

public class Soldier : MonoBehaviour
{
    public bool isPossessed;

    public float possessionTimer;
    public float possessionDuration = 10f;

    void Update()
    {
        if (!isPossessed) // if im not possessed, ignore.
            return;

        possessionTimer -= Time.deltaTime; // otherwise, start a countdown

        if (possessionTimer <= 0f) 
        {
            isPossessed = false;
        }
    }

    public void Possess()
    {
        isPossessed = true;
        possessionTimer = possessionDuration;
    }
}