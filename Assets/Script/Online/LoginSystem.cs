using LootLocker.Requests;
using UnityEngine;
using static UpgradeManager;


public class LoginSystem : MonoBehaviour
{
    public static LoginSystem Instance {  get; private set; }
    private int player_id;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        Login();
    }
    void Update()
    {
        
    }
    void Login()
    {
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                player_id = response.player_id;
                Debug.Log("Đăng nhập thành công!");
            }
            else
            {
                Debug.LogError("Đăng nhập thất bại.");
            }
        });
    }
    public void CreateNewTestPlayer(int slot)
    {
        PlayerPrefs.DeleteKey("LootLockerGuestPlayerID");

        LootLockerSDKManager.StartGuestSession(response =>
        {
            if (response.success)
            {
                string newID = response.player_id.ToString();
                Debug.Log($"Player mới (Slot {slot}): {newID}");

                PlayerPrefs.SetString($"TestPlayerID_Slot{slot}", newID);
            }
            else
            {
                Debug.LogError("Không thể tạo player mới.");
            }
        });
    }
    public int GetPlayerID()
    {
        return player_id;
    }
    public void Create(ref LoginSaveData data)
    {
       data.player_id = player_id;
    }
    public void Save(ref LoginSaveData data)
    {
        data.player_id = player_id;
    }
    [System.Serializable]
    public struct LoginSaveData
    {
        public int player_id;
    }

}
