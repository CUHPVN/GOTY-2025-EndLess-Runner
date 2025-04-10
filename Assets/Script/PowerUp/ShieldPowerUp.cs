using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Player"))
		{
			PowerUp.Instance.StartShieldPowerUp();
			transform.gameObject.SetActive(false);
		}
	}
}
