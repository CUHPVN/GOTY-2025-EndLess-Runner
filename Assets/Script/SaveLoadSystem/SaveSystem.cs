using System.IO;
using UnityEngine;

public class SaveSystem
{
	private static SaveData saveData;
	
	[System.Serializable]
	public struct SaveData
	{
		// thêm loại data mới vào đây, VD ở đây thì cái tên của struct cần save trong file CoinManager là SaveCoinData
		public SaveCoinData CoinData;
	}
	public static string SaveFileName()
	{
		string saveFile = Application.persistentDataPath + "/save" + ".dat";//đổi tên file + tên đuôi nếu muốn
		return saveFile;
	}
	public static void Save()
	{
		HandleSaveData();
		
		File.WriteAllText(SaveFileName(),JsonUtility.ToJson(saveData, true));
	}
	private static void HandleSaveData()
	{
		// Thêm cái method mới cho save ở đây tạo tương tự cái này
		CoinManager.Instance.Save(ref saveData.CoinData);
	}
	
	public static void Load()
	{
		string saveContent = File.ReadAllText(SaveFileName());
		
		saveData = JsonUtility.FromJson<SaveData>(saveContent);
		HandleLoadData();
	}
	
	private static void HandleLoadData()
	{
		// Thêm cái method mới cho load ở đây tạo tương tự cái này
		CoinManager.Instance.Load(saveData.CoinData);
	}
	// cần Save ở đâu thì gọi SaveSystem.Save();
	// cần Load Ở đâu thì gọi SaveSystem.Load();
}
