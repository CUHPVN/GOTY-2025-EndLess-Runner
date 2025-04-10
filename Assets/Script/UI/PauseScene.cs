using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScene : MonoBehaviour
{
	private void OnEnable()
	{
		Time.timeScale = 0f;
	}
	public void Resume()
	{
		transform.gameObject.SetActive(false);
	}
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
	{
		Application.Quit();
	}
	private void OnDisable()
	{
		Time.timeScale = 1f;
	}
}
