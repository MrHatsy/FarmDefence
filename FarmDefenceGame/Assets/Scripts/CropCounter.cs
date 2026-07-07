using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CropCounter : MonoBehaviour
{
    private PointManager myPointManager;
    [SerializeField] private TextMeshProUGUI cropCounter;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myPointManager = FindFirstObjectByType<PointManager>();
    }

    // Update is called once per frame
    void Update()
    {
        cropCounter.text = string.Format("Crops: {0} / 180", myPointManager.Points);
    }
}
