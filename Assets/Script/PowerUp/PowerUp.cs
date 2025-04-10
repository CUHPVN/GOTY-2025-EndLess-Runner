using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
	public static PowerUp Instance { get; private set; }
	public float ShieldDuration;
	public float X2CoinDuration;
	
	float CurrentShieldDuration;
	float CurrentX2CoinDuration;
	
	public bool ShieldActive = false;
	public bool X2CoinActive = false;
	
	void Awake()
	{
		if(Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(gameObject);
			return;
		}
		DontDestroyOnLoad(this);
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
		
		
		CurrentShieldDuration -= Time.deltaTime; 
		if(CurrentShieldDuration >= 0)
		{
			ShieldActive = true;
		}
		else
		{
			ShieldActive = false;
		}
		CurrentX2CoinDuration -= Time.deltaTime;
		if(CurrentX2CoinDuration >= 0)
		{
			X2CoinActive = true;
		}
		else
		{
			X2CoinActive = false;
		}
		
		
	}

	public void StartShieldPowerUp()
	{
		CurrentShieldDuration = ShieldDuration;
	}
	
	public void BreakShieldPowerUp()
	{
		CurrentShieldDuration = 0;
	}
	
	
	public void StartX2CoinPowerUp()
	{
		CurrentX2CoinDuration = X2CoinDuration;
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