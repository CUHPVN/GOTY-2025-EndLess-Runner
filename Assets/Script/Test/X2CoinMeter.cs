using UnityEngine;
using UnityEngine.UI;

public class X2CoinMeter : MonoBehaviour
{
	Image PowerMeter;

	private void Start()
	{
		PowerMeter = GetComponent<Image>();
	}
	private void Update()
	{
		PowerMeter.fillAmount = PowerUp.Instance.CurrentX2CoinDuration / PowerUp.Instance.X2CoinDuration;
	}
}
