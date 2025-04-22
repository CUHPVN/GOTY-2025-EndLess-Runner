using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadScene : MonoBehaviour
{
	public TextMeshProUGUI ScoreText;
	public TextMeshProUGUI CoinText;
	private void OnEnable()
	{
		GameManager.Instance.AddScore((int)UIManager.Instance.GetScore());
		SaveSystem.Save();
		ScoreText.text = $"{(int)UIManager.Instance.GetScore()}";
		CoinText.text = $"{CoinManager.Instance.GetCoin()}";
	}
	public void Restart()
	{
		TransitionManager.Instance.PlayAgainInGame();
	}
	public void ReturnMainMenu()
	{
		if (SceneManager.GetActiveScene().name == "Tutorial") GameManager.Instance.SetIsFirst();
		TransitionManager.Instance.PlayOutInGame();
	   
	}
   
}
