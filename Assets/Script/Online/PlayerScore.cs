using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private TMP_Text Rank;
    [SerializeField] private TMP_Text Name;
    [SerializeField] private TMP_Text Score;
    [SerializeField] private Image Avatar;
    void Start()
    {
        Rank = transform.GetChild(0).GetComponent<TMP_Text>();
        Name = transform.GetChild(1).GetComponent<TMP_Text>();
        Score = transform.GetChild(2).GetComponent<TMP_Text>();
        Avatar = transform.GetChild(3).GetChild(0).GetComponent<Image>();
    }

    void Update()
    {
        
    }
    public void SetScore(int score)
    {
        if (Score == null)
        Score = transform.GetChild(2).GetComponent<TMP_Text>();
        Score.text = ""+score;
    }
    public void SetName(string name)
    {
        if(Name == null)
        Name = transform.GetChild(1).GetComponent<TMP_Text>();
        Name.text = name;
    }
    public void SetRank(int rank)
    {
        if (Rank == null)
            Rank = transform.GetChild(0).GetComponent<TMP_Text>();
        Rank.text = ""+rank;
    }
    public void SetAvatar(int ava)
    {
        if (Avatar == null&&transform!=null)
            Avatar = transform.GetChild(3).GetChild(0).GetComponent<Image>();
        if (Avatar == null) return;
        Avatar.sprite = GameManager.Instance.GetAvaSpriteByIndex(ava);
    }
}
