using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	public static UIManager Instance { get; private set; }
	TextMeshProUGUI ScoreText;
	
	public GameObject DeadScene;
	public float Score = 0;
	public int Multiplyer;

	void Awake()
	{
		Instance = this;
	}
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		ScoreText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
	}

	// Update is called once per frame
	void Update()
	{
		ScoreText.text = $"Score: {(int)Score}";
		if(StateManager.Instance.GetState() == StateManager.States.Dead)
		{
			Time.timeScale = 0f;
			DeadScene.SetActive(true);
		}
	}
	private void FixedUpdate()
	{
		Score += 1f * Multiplyer * 0.3f;
	}

	public float GetScore()
	{
		return Score;
	}
}
