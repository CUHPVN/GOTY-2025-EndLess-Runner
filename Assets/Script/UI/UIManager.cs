using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	bool isPause = false;
	public static UIManager Instance { get; private set; }
	[SerializeField] private TextMeshProUGUI ScoreText;
	[SerializeField] private TextMeshProUGUI CoinCounter;
	
	public GameObject DeadScene;
	public GameObject PauseScene;
	public float Score = 0;
	public int Multiplyer;

	void Awake()
	{
		Instance = this;
	}
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{

		TransitionManager.Instance.PlayIn();
	}

	// Update is called once per frame
	void Update()
	{
		isPause = PauseScene.activeSelf;
		ScoreText.text = $"Score: {(int)Score}";
		CoinCounter.text = $"{CoinManager.Instance.GetCoin()}";
		if(StateManager.Instance.GetState() == StateManager.States.DeadState)
		{
			Time.timeScale = 0f;
			DeadScene.SetActive(true);
		}
		else if(Input.GetKeyDown(KeyCode.Escape) && !isPause)
		{
			PauseScene.SetActive(true);
			isPause = true;
		}
		else if(Input.GetKeyDown(KeyCode.Escape) && isPause)
		{
			PauseScene.SetActive(false);
			isPause = false;
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
