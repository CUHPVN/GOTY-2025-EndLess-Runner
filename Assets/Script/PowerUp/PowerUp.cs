using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
	public static PowerUp Instance { get; private set; }
	public float ShieldDuration;
	public float X2CoinDuration;
	public float X2ScoreDuration;

	public float CurrentShieldDuration;
	public float CurrentX2CoinDuration;
	public float CurrentX2ScoreDuration;
	public bool ShieldActive = false;
	public bool X2CoinActive = false;
	public bool X2ScoreActive = false;

	void Awake()
	{
		if (Instance == null)
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
		if (Input.GetKeyDown(KeyCode.Alpha1) && ShieldActive == false)
		{
			StartShieldPowerUp();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2) && X2CoinActive == false)
		{
			StartX2CoinPowerUp();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3) && X2ScoreActive == false)
		{
			StartX2ScorePowerUp();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			BreakShieldPowerUp();
			MapSpawner.Instance.MSetBase();
			StartX2CoinPowerUp();
			StartX2ScorePowerUp();
		}


		CurrentShieldDuration -= Time.deltaTime;
		if (CurrentShieldDuration > 0)
		{
			ShieldActive = true;
		}
		else
		{
			ShieldActive = false;
		}
		CurrentX2CoinDuration -= Time.deltaTime;
		if (CurrentX2CoinDuration > 0)
		{
			X2CoinActive = true;
		}
		else
		{
			X2CoinActive = false;
		}
		CurrentX2ScoreDuration -= Time.deltaTime;
		if (CurrentX2ScoreDuration > 0)
		{
			X2ScoreActive = true;
		}
		else
		{
			X2ScoreActive = false;
		}


	}

	public void StartShieldPowerUp()
	{
		CurrentShieldDuration = ShieldDuration;
	}

	public void BreakShieldPowerUp()
	{
		CurrentShieldDuration = 0;
		ShieldEffect.Instance.StartEffect();
	}


	public void StartX2CoinPowerUp()
	{
		CurrentX2CoinDuration = X2CoinDuration;
	}
	public void StartX2ScorePowerUp()
	{
		CurrentX2ScoreDuration = X2ScoreDuration;
	}
	public void SetDuration(int index, float value)
	{
		switch (index)
		{
			case 0:
				ShieldDuration = value;	
				break;
			case 1:
				X2CoinDuration = value;
				break;
			case 2:
				X2ScoreDuration = value;
				break;
			default:
				Debug.Log("Invalid index");
				break;
		}
	}


}
/*
public void Save(ref PowerUpSaveData data)
{
	data.ShieldDurationData = ShieldDuration;
	data.X2CoinDurationData = X2CoinDuration;
}
public void Load(PowerUpSaveData data)
{
	ShieldDuration = data.ShieldDurationData;
	X2CoinDuration = data.X2CoinDurationData;
}*/

[System.Serializable]
public struct PowerUpSaveData
{
	public float ShieldDurationData;
	public float X2CoinDurationData;
}