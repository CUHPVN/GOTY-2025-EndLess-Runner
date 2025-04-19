using UnityEngine;

public class Revive : MonoBehaviour
{
	public GameObject DeadScene;
	public void Yes()
	{
		MapSpawner.Instance.SetBase();
		PowerUp.Instance.BreakShieldPowerUp();
		StateManager.Instance.ChangeState(StateManager.Instance.GetLateState());
		Time.timeScale = 1f;
		gameObject.SetActive(false);
	}
	public void No()
	{
		gameObject.SetActive(false);
		DeadScene.SetActive(true);
	}
}
