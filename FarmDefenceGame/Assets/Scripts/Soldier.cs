using UnityEngine;

public class Soldier : MonoBehaviour
{
    public bool isPossessed;

    public float possessionTimer;
    public float possessionDuration = 15f;

    void Update()
    {
        if (!isPossessed)
            return;

        possessionTimer -= Time.deltaTime;

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