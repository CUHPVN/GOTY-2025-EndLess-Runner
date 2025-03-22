using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    TextMeshProUGUI ScoreText;
    int Score = 0;
    public int Multiplyer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ScoreText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
        ScoreText.text = $"Score: {Score}";
    }
    private void FixedUpdate()
    {
        Score += 1 * Multiplyer;
    }
}
