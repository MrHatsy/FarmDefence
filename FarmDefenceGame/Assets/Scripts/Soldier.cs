using UnityEngine;

public class Soldier : MonoBehaviour
{
    public bool isPossessed;

    public float possessionTimer;
    public float possessionDuration = 10f;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    void Update()
    {
        if (!isPossessed) // if im not possessed, ignore.
            return;

        possessionTimer -= Time.deltaTime; // otherwise, start a countdown

        if (possessionTimer <= 0f) 
        {
            if (PlayerMovement.possessedSoldiers.Count > 0)
            {
                PlayerMovement.possessedSoldiers.Remove(this);
            }
            isPossessed = false;
            spriteRenderer.color = originalColor;
        }
    }

    public void Possess()
    {
        isPossessed = true;
        possessionTimer = possessionDuration;
        spriteRenderer.color = Color.white;
    }

    public void RemovePossession()
{
    isPossessed = false;
    spriteRenderer.color = originalColor;
}
}