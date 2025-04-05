using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
	public static PowerUp Instance { get; private set; }
	public float ShieldDuration;
	public float X2CoinDuration;
	
	public bool ShieldActive = false;
	public bool X2CoinActive = false;
	
	private void Awake()
	{
		Instance = this;
	}

	private void Update()
	{
		//Debug
		if(Input.GetKeyDown(KeyCode.Alpha1) && ShieldActive == false)
		{
			StartShieldPowerUp();
		}
		else if(Input.GetKeyDown(KeyCode.Alpha2) && X2CoinActive == false)
		{
			StartX2CoinPowerUp();
		}
	}

	public void StartShieldPowerUp()
	{
		StartCoroutine(ShieldPowerUp());
	}
	
	IEnumerator ShieldPowerUp()
	{
		ShieldActive = true;
		yield return new WaitForSeconds(ShieldDuration);
		ShieldActive = false;
	}
	
	
	public void StartX2CoinPowerUp()
	{
		StartCoroutine(X2CoinPowerUp());
	}
	
	IEnumerator X2CoinPowerUp()
	{
		X2CoinActive = true;
		yield return new WaitForSeconds(X2CoinDuration);
		X2CoinActive = false;
	}
	
	public void Save(ref PowerUpSaveData data)
	{
		data.ShieldDurationData = ShieldDuration;
		data.X2CoinDurationData = X2CoinDuration;
	}
	public void Load(PowerUpSaveData data)
	{
		ShieldDuration = data.ShieldDurationData;
		X2CoinDuration = data.X2CoinDurationData;
	}
}
[System.Serializable]
public struct PowerUpSaveData
{
	public float ShieldDurationData;
	public float X2CoinDurationData;
}