using UnityEngine;

public class CoinManager : MonoBehaviour
{
	public static CoinManager Instance { get; private set; }
	public int TotalCoin;
	
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
	
	public void AddCoin(int amount)
	{
		TotalCoin += amount;
	}
	
	public void RemoveCoin(int amount)
	{
		TotalCoin -= amount;
	}
	public int GetCoin()
	{
		return TotalCoin;
	}
	// SaveLoadSystem, cần lưu cái j thì tạo 2 hàm như thế này
	public void Save(ref SaveCoinData data)
	{
		data.CoinTotal = TotalCoin;
	}
	public void Load(SaveCoinData data)
	{
		TotalCoin = data.CoinTotal;
	}
	public void ResetCoin()
	{
		TotalCoin = 0;
	}
}

// data cần lưu trong file này, dùng struct, muốn tạo trong file khác thì tạo tương tự

[System.Serializable]
public struct SaveCoinData
{
	public int CoinTotal;
}
