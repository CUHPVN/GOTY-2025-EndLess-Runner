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
    public void AddPlayer(int rank,string name, int score)
    {
        Transform player = Instantiate(prefabs);
        player.transform.SetParent(content);
        player.transform.localScale = new Vector3(1, 1, 1);
        PlayerScore playerScore = player.GetComponent<PlayerScore>();
        playerScore.SetRank(rank);
        playerScore.SetName(name);
        playerScore.SetScore(score);
    }
}
