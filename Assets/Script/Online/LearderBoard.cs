using LootLocker;
using LootLocker.Requests;
using Unity.VisualScripting;
using UnityEngine;

public class LearderBoard : MonoBehaviour
{
    public static LearderBoard Instance { get; private set; }
    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Send(int score)
    {
        string leaderboardKey = "your_leaderboard_key";

        LootLockerSDKManager.SubmitScore("", score, leaderboardKey, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Gửi điểm số thành công!");
            }
            else
            {
                Debug.LogError("Gửi điểm số thất bại, hãy bật wifi và chơi ở loading scene!");
            }
        });
    }
    public void SetName(string name)
    {
        LootLockerSDKManager.SetPlayerName(name, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Tên người chơi đã được gán!");
                LoginSystem.Instance.Login();
            }
            else
                Debug.LogError("Không thể gán tên.");
        });

    }
    public int GetHightScore(string playerID)
    {
        string leaderboardKey = "your_leaderboard_key";
        int score=0;
        LootLockerSDKManager.GetMemberRank(leaderboardKey, playerID, (response) =>
        {
            if (!response.success)
            {
                Debug.Log("Could not get the entry!");
                Debug.Log(response.errorData.ToString());
                score = 0;
                return;
            }
            //Debug.Log("Successfully got entry!");
            score = response.score;
        });
        return score;
    }
    public void Get()
    {
        int count = 10; 
        int after = 0; 

        LootLockerSDKManager.GetScoreList("your_leaderboard_key", count, after, (response) =>
        {
            if (response.success)
            {
                LeaderBoardUIManager.Instance.Clear();
                foreach (var entry in response.items)
                {
                    if(entry.player.id == LoginSystem.Instance.GetPlayerID())
                    {
                        LeaderBoardUIManager.Instance.AddPlayer(entry.rank,entry.player.name+" (YOU)", entry.score);

                    }else
                        LeaderBoardUIManager.Instance.AddPlayer(entry.rank,entry.player.name, entry.score);
                    //Debug.Log($"Player: {entry.player.name}, Score: {entry.score}");
                }
            }
            else
            {
                //Debug.LogError("Lấy danh sách bảng xếp hạng thất bại.");
            }
        });

    }
}
