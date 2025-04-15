using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadScene : MonoBehaviour
{
	TextMeshProUGUI ScoreText;
	private void OnEnable()
	{
		SaveSystem.Save();
		ScoreText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
		ScoreText.text = $"Score: {(int)UIManager.Instance.GetScore()}";
	}
    public void Restart()
    {
        TransitionManager.Instance.PlayAgainInGame();
    }
    public void ReturnMainMenu()
    {
        TransitionManager.Instance.PlayOutInGame();
       
    }
   
}
