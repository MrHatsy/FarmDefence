using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject mmPanel;
    [SerializeField] private Button startButton;

    static private UIManager instance;
    static private UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("There is no UIManager in the scene");
            }
            return instance;
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startButton.onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }
}
