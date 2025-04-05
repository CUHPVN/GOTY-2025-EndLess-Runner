using UnityEngine;

public class Coin : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Player"))
		{
			CoinManager.Instance.AddCoin(1);
			transform.gameObject.SetActive(false);
		}
	}
}
