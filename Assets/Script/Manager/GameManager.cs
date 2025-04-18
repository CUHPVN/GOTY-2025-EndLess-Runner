using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        //SaveSystem.Load();

    }
    void FPS()
    {
        Application.targetFrameRate = -1; 
        QualitySettings.vSyncCount = 0;
    }
    void Update()
    {
        
    }
}
