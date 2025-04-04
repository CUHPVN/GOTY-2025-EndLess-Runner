using UnityEngine;

public class Coin : MonoBehaviour
{
	public int amount = 1;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Player"))
		{
			if(PowerUp.Instance.X2CoinActive)
			{
				CoinManager.Instance.AddCoin(2);
			}
			else
			{
				CoinManager.Instance.AddCoin(1);
			}
			transform.gameObject.SetActive(false);
		}
	}
}
