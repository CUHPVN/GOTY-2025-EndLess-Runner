using UnityEngine;
using UnityEngine.UI;

public class ShieldMeter : MonoBehaviour
{
    Image PowerMeter;

	private void Start()
	{
		PowerMeter = GetComponent<Image>();
	}
    private void Update()
    {
        PowerMeter.fillAmount = PowerUp.Instance.CurrentShieldDuration / PowerUp.Instance.ShieldDuration;
    }
}
