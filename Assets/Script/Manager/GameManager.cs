using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private int score=0;
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
    public void AddScore(int score)
    {
        if(this.score < score) {
            this.score = score;
        }
    }
    public void Load(GameSaveData data)
    {
        score= data.score;
    }
    public void Create(ref GameSaveData data)
    {
        data.score = score;
    }
    public void Save(ref GameSaveData data)
    {
        data.score = score;
        LearderBoard.Instance.Send(score);
    }
}
[System.Serializable]
public struct GameSaveData
{
    public int score;
}
