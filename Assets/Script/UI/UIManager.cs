using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	bool isPause = false;
	public static UIManager Instance { get; private set; }
	TextMeshProUGUI ScoreText;
	
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
		ScoreText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
	}

	// Update is called once per frame
	void Update()
	{
		isPause = PauseScene.activeSelf;
		ScoreText.text = $"Score: {(int)Score}";
		if(StateManager.Instance.GetState() == StateManager.States.Dead)
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
