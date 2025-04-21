using TMPro;
using UnityEngine;

public class Revive : MonoBehaviour
{
	public TMP_Text text;
	public GameObject DeadScene;
    private void OnEnable()
    {
        SaveSystem.Save();
        text.text = $"{(int)(UIManager.Instance.GetScore() / 10f)}";
    }
    public void Yes()
	{
		int req = (int)(UIManager.Instance.GetScore() / 10f);
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
