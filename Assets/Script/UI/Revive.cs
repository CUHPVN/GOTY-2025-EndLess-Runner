using TMPro;
using UnityEngine;

public class Revive : MonoBehaviour
{
	public bool InTutorial = false;
	public int deathCount = 0;
	public TMP_Text text;
	public GameObject DeadScene;
	private void OnEnable()
	{
		deathCount++;
		SoundManager.Instance.PlaySFX((int)SoundManager.SoundType.ShieldBreak);
		text.text = $"{(int)(UIManager.Instance.GetScore() / 10f * deathCount)}";
		if(InTutorial)
		{
			No();
		}
	}
	public void Yes()
	{
		int req = (int)(UIManager.Instance.GetScore() / 10f * deathCount);
		if (CoinManager.Instance.GetCoin() < req) return;
		CoinManager.Instance.RemoveCoin(req);
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
