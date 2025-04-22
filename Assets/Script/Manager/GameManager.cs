using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private int score=0;
    [SerializeField] private bool isFirst = true;
    [SerializeField] private string playerName;
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
        if(LoginSystem.Instance != null)
        {
            SetName(LoginSystem.Instance.GetPlayerName());
            if (playerName == "")
            {
                playerName = "Guest";
            }
        }
        else
        {
            SetName("OfflinePlayer");
        }
    }
    void FPS()
    {
        Application.targetFrameRate = -1; 
        QualitySettings.vSyncCount = 0;
    }
    public int GetScore()
    {
        return score;
    }
    public bool GetIsFirst()
    {
        if(score != 0) isFirst = false; 
        return isFirst;
    }
    public void SetIsFirst()
    {
        isFirst = false;
    }
    public void AddScore(int score)
    {
        if(this.score < score) {
            this.score = score;
        }
    }
    public string GetName()
    {
        return playerName;
    }
    public void SetName(string name)
    {
        playerName = name;
    }
    public void UpdateName()
    {
        playerName = LoginSystem.Instance.GetPlayerName();
        if (LearderBoard.Instance != null)
        {
            LearderBoard.Instance.Get();
        }
    }
    public void SendName(string name)
    {
        if(LearderBoard.Instance != null)
        {
            LearderBoard.Instance.SetName(name);
        }
        else
        {
            Debug.Log("Send Name không thành công!");
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
        if(LearderBoard.Instance != null) 
        LearderBoard.Instance.Send(score);
    }
    private void OnApplicationQuit()
    {
        SaveSystem.Save();
    }
}
[System.Serializable]
public struct GameSaveData
{
    public int score;
}
