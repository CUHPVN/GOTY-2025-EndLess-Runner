using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Player"))
		{
            SoundManager.Instance.PlaySFX((int)SoundManager.SoundType.CoinPickup);
            PowerUp.Instance.StartShieldPowerUp();
			transform.gameObject.SetActive(false);
		}
	}
}
