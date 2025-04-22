using UnityEngine;

public class X2ScorePowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Player"))
        {
            SoundManager.Instance.PlaySFX((int)SoundManager.SoundType.PUPickup);
            PowerUp.Instance.StartX2ScorePowerUp();
			transform.gameObject.SetActive(false);
		}
	}
}
