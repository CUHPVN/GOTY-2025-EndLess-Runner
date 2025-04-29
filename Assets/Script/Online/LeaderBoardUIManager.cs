using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class LeaderBoardUIManager : MonoBehaviour
{
    public static LeaderBoardUIManager Instance { get; private set; }
    [SerializeField] private Transform content;
    [SerializeField] private Transform prefabs;
    [SerializeField] private List<Transform> playerScores = new();

    private void Awake()
    {
        Instance = this;
    }
    void Update()
    {
           
    }
    public void Clear()
    {
        foreach (Transform t in playerScores)
        {
            Destroy(t.gameObject);
        }
        playerScores.Clear();
    }
    public void AddPlayer(int rank,string name, int score, int id)
    {
        Transform player = Instantiate(prefabs);
        playerScores.Add(player);
        player.transform.SetParent(content);
        player.transform.localScale = new Vector3(1, 1, 1);
        PlayerScore playerScore = player.GetComponent<PlayerScore>();
        playerScore.SetRank(rank);
        playerScore.SetName(name);
        playerScore.SetScore(score);
        int index = 0;
        if(LearderBoard.Instance != null)
        {
            LearderBoard.Instance.GetAvarOfPlayer(id, (avar) =>
            {
                if (!string.IsNullOrEmpty(avar))
                {
                    index = int.Parse(avar);
                    playerScore.SetAvatar(index);
                }   
                else
                {
                    Debug.Log("Không tìm thấy avar hoặc lỗi khi lấy avar.");
                }
            });
        }
        //playerScore.SetAvatar(index);
    }
}
