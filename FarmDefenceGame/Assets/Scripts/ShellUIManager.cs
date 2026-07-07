using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class ShellUIManager : MonoBehaviour
{

    public delegate void OnLevelPauseEventHandler();
    public event OnLevelPauseEventHandler OnLevelPause;

    public delegate void OnLevelUnPauseEventHandler();
    public event OnLevelUnPauseEventHandler OnLevelUnPause;


    [SerializeField] private GameObject pausePanel;

    [SerializeField] private GameObject winPanel;

    static private ShellUIManager instance;
    static public ShellUIManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("NO SHELLUI in scene");
            }
            return instance;
        }
    }
    PlayerActions actions;
    InputAction pauseAction;
    bool isPaused = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        UnPause();

    }

    private void Awake()
    {
        actions = new PlayerActions();

        pauseAction = actions.flying.Pause;

        pauseAction.performed += OnPause;
    }

    void OnEnable()
    {
        pauseAction.Enable();
    }

    void OnDisable()
    {
        pauseAction.Disable();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void Pause()
    {
        OnLevelPause?.Invoke();
        isPaused = true;
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    private void UnPause()
    {
        OnLevelUnPause?.Invoke();
        isPaused = false;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    private void OnPause(InputAction.CallbackContext context)
    {
        if (isPaused)
        {
            UnPause();
        }
        else
        {
            Pause();
        }
        Debug.Log("game paused");
    }
}
