using UnityEngine;

public class X2CoinPowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Player"))
        {
            SoundManager.Instance.PlaySFX((int)SoundManager.SoundType.CoinPickup);
            PowerUp.Instance.StartX2CoinPowerUp();
			transform.gameObject.SetActive(false);
		}
	}
}
