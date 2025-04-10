using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadScene : MonoBehaviour
{
	TextMeshProUGUI ScoreText;
	private void OnEnable()
	{
		ScoreText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
		ScoreText.text = $"Score: {(int)UIManager.Instance.GetScore()}";
	}
	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
