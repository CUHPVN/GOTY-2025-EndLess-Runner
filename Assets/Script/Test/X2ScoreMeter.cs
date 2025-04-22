using UnityEngine;
using UnityEngine.UI;

public class X2ScoreMeter : MonoBehaviour
{
	Image PowerMeter;

	private void Start()
	{
		PowerMeter = GetComponent<Image>();
	}
	private void Update()
	{
		PowerMeter.fillAmount = PowerUp.Instance.CurrentX2ScoreDuration / PowerUp.Instance.X2ScoreDuration;
	}
}
