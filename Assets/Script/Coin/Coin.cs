using UnityEngine;

public class Coin : MonoBehaviour
{
	Animator anim;

	public int amount = 1;
	private void Start()
	{
		anim = GetComponent<Animator>();
	}

	private void Update()
	{
		anim.SetBool("X2",PowerUp.Instance.X2CoinActive);
		
	}
	public void EatCoin()
	{
		SoundManager.Instance.PlaySFX((int)SoundManager.SoundType.CoinPickup);
        if (PowerUp.Instance.X2CoinActive)
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
