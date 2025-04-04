using UnityEngine;

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
	public void Quit()
	{
		Application.Quit();
	}
	private void OnDisable()
	{
		Time.timeScale = 1f;
	}
}
