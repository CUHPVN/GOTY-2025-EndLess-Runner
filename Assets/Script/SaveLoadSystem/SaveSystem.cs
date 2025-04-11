using System.IO;
using UnityEngine;
using static UpgradeManager;

public class SaveSystem
{
	private static SaveData saveData;
	
	[System.Serializable]
	public struct SaveData
	{
		// thêm loại data mới vào đây, VD ở đây thì cái tên của struct cần save trong file CoinManager là SaveCoinData
		public SaveCoinData CoinData;
		//public PowerUpSaveData PowerUpData;
		public UpgradeSaveData UpgradeData;
	}
	public static string SaveFileName()
	{
		string saveFile = Application.persistentDataPath + "/save" + ".dat";//đổi tên file + tên đuôi nếu muốn
		return saveFile;
	}
	public static void Save()
	{
		HandleSaveData();
		Debug.Log("Save file: " + SaveFileName());
		File.WriteAllText(SaveFileName(),JsonUtility.ToJson(saveData, true));
	}
	private static void HandleSaveData()
	{
		// Thêm cái method mới cho save ở đây tạo tương tự cái này
		CoinManager.Instance.Save(ref saveData.CoinData);
		//PowerUp.Instance.Save(ref saveData.PowerUpData);
		UpgradeManager.Instance.Save(ref saveData.UpgradeData);
	}
	public static void CreateSave()
	{
		HandleCreateSaveData();
        Debug.Log("Create Save file: " + SaveFileName());
        File.WriteAllText(SaveFileName(), JsonUtility.ToJson(saveData, true));
    }
	private static void HandleCreateSaveData()
	{
        CoinManager.Instance.Create(ref saveData.CoinData);
        UpgradeManager.Instance.Create(ref saveData.UpgradeData);
    }
	
	public static void Load()
	{
		if(!File.Exists(SaveFileName()))
		{
			Debug.Log("Save file not found");
			//Save();
			CreateSave();
		}
		Debug.Log("Load file: " + SaveFileName());
		string saveContent = File.ReadAllText(SaveFileName());
		
		saveData = JsonUtility.FromJson<SaveData>(saveContent);
		HandleLoadData();
	}
	
	private static void HandleLoadData()
	{
		// Thêm cái method mới cho load ở đây tạo tương tự cái này
		CoinManager.Instance.Load(saveData.CoinData);
		//PowerUp.Instance.Load(saveData.PowerUpData);
		UpgradeManager.Instance.Load(saveData.UpgradeData);
	}
	// cần Save ở đâu thì gọi SaveSystem.Save();
	// cần Load Ở đâu thì gọi SaveSystem.Load();
	
	
	
	public static void DeleteSave()
	{
		File.Delete(SaveFileName());
		Load();
	}
}
