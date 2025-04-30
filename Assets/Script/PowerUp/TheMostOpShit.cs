using UnityEngine;

public class TheMostOpShit : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Player"))
		{
			SoundManager.Instance.PlaySFX((int)SoundManager.SoundType.PUPickup);
			PowerUp.Instance.BreakShieldPowerUp();
			MapSpawner.Instance.MSetBase();
			PowerUp.Instance.StartX2CoinPowerUp();
			PowerUp.Instance.StartX2ScorePowerUp();
			
			transform.gameObject.SetActive(false);
		}
	}
}
