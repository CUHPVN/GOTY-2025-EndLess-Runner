using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;
using static UpgradeManager;

public class SaveSystem
{
	private static SaveData saveData;
    private static string key = "your-32-character-super-cuhp-vn!"; 
    private static string iv = "plan-16-craftIV!";
    [System.Serializable]
	public struct SaveData
	{
		// thêm loại data mới vào đây, VD ở đây thì cái tên của struct cần save trong file CoinManager là SaveCoinData
		public SaveCoinData CoinData;
		//public PowerUpSaveData PowerUpData;
		public UpgradeSaveData UpgradeData;
        public SoundSaveData SoundData;
		public GameSaveData GameData;
    }
	public static string SaveFileName()
	{
		string saveFile = Application.persistentDataPath + "/save" + ".data";//đổi tên file + tên đuôi nếu muốn
		return saveFile;
	}
	public static void Save()
	{
		HandleSaveData();
		Debug.Log("Save file: " + SaveFileName());
        string json = JsonUtility.ToJson(saveData, true);
        string encrypted = Encrypt(json);
        File.WriteAllText(SaveFileName(),encrypted);
	}
	private static void HandleSaveData()
	{
        // Thêm cái method mới cho save ở đây tạo tương tự cái này
        if (SoundManager.Instance != null)
            SoundManager.Instance.Save(ref saveData.SoundData);
        if (CoinManager.Instance != null)
            CoinManager.Instance.Save(ref saveData.CoinData);
		//PowerUp.Instance.Save(ref saveData.PowerUpData);
		if(UpgradeManager.Instance!=null)
		UpgradeManager.Instance.Save(ref saveData.UpgradeData);
        if (GameManager.Instance != null)
            GameManager.Instance.Save(ref saveData.GameData);
	}
	public static void CreateSave()
	{
		HandleCreateSaveData();
        Debug.Log("Create Save file: " + SaveFileName());
        string json = JsonUtility.ToJson(saveData, true);
        string encrypted = Encrypt(json);
        Debug.Log(encrypted);
        File.WriteAllText(SaveFileName(), encrypted);
        //Load();
    }
	private static void HandleCreateSaveData()
	{
        CoinManager.Instance.Create(ref saveData.CoinData);
        SoundManager.Instance.Create(ref saveData.SoundData);
        UpgradeManager.Instance.Create(ref saveData.UpgradeData);
        GameManager.Instance.Create(ref saveData.GameData);
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
        string encrypted = File.ReadAllText(SaveFileName());
        string decrypted = Decrypt(encrypted);
		saveData = JsonUtility.FromJson<SaveData>(decrypted);
		HandleLoadData();
	}
	
	private static void HandleLoadData()
	{
		// Thêm cái method mới cho load ở đây tạo tương tự cái này
		CoinManager.Instance.Load(saveData.CoinData);
        SoundManager.Instance.Load(saveData.SoundData);
        //PowerUp.Instance.Load(saveData.PowerUpData);
        if (UpgradeManager.Instance != null)
            UpgradeManager.Instance.Load(saveData.UpgradeData);
		if (GameManager.Instance!=null)
            GameManager.Instance.Load(saveData.GameData);

    }
    // cần Save ở đâu thì gọi SaveSystem.Save();
    // cần Load Ở đâu thì gọi SaveSystem.Load();

    private static string Encrypt(string plainText)
    {
        try
        {
            using Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = Encoding.UTF8.GetBytes(iv);

            using MemoryStream ms = new MemoryStream();
            using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
            using (StreamWriter sw = new StreamWriter(cs))
            {
                sw.Write(plainText);
            }

            return Convert.ToBase64String(ms.ToArray());
        }
        catch (Exception ex)
        {
            Debug.LogError("❌ Encrypt error: " + ex.Message);
            return null;
        }
    }

    private static string Decrypt(string cipherText)
    {
        using Aes aes = Aes.Create();
        //ValidateKeyAndIV(key, iv);
        aes.Key = Encoding.UTF8.GetBytes(key);
        aes.IV = Encoding.UTF8.GetBytes(iv);

        ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
        using MemoryStream ms = new MemoryStream(Convert.FromBase64String(cipherText));
        using CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
        using StreamReader sr = new StreamReader(cs);

        return sr.ReadToEnd();
    }
    private static void ValidateKeyAndIV(string key, string iv)
    {
        int keyLength = Encoding.UTF8.GetBytes(key).Length;
        int ivLength = Encoding.UTF8.GetBytes(iv).Length;

        Debug.Log($"Key length: {keyLength} bytes");
        Debug.Log($"IV length: {ivLength} bytes");

        if (keyLength != 16 && keyLength != 24 && keyLength != 32)
        {
            Debug.LogError("Key phải có độ dài 16, 24 hoặc 32 byte!");
        }
        else
        {
            Debug.Log("Key hợp lệ.");
        }

        if (ivLength != 16)
        {
            Debug.LogError("IV phải có độ dài chính xác 16 byte!");
        }
        else
        {
            Debug.Log("IV hợp lệ.");
        }
    }
    public static void DeleteSave()
	{
		File.Delete(SaveFileName());
		Load();
	}
}
