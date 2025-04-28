using System.Collections;
using LootLocker.Requests;
using UnityEngine;
using static UpgradeManager;


public class LoginSystem : MonoBehaviour
{
    public static LoginSystem Instance {  get; private set; }
    private int player_id;
    private string player_name;
    private string player_avar="0";
    private string player_frame="0";
    public float checkInterval = 10f;
    private bool isLoggedIn = false;

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        //Login();
        StartCoroutine(CheckAndReconnectLoop());
    }
    void Update()
    {
        
    }
    public void Login()
    {
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                player_id = response.player_id;
                player_name = response.player_name;
                //Debug.Log("Đăng nhập thành công!");
                if(GameManager.Instance != null)
                {
                    GameManager.Instance.UpdateName();
                }
            }
            else
            {
                Debug.LogError("Đăng nhập thất bại.");
            }
        });
        LootLockerSDKManager.GetSingleKeyPersistentStorage("avar", (response) =>
        {
            if (response.success)
            {
                string avar = response.payload.value;
                player_avar = avar;
                //Debug.Log("Avar hiện tại: " + avar);
                if (PlayerInfor.Instance != null)
                {
                    GameManager.Instance.DownAvatar();
                }
            }
            else
            {
                Debug.LogError("Lấy avar thất bại: " + response.errorData.message);
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
    IEnumerator CheckAndReconnectLoop()
    {
        while (true)
        {
            if (!isLoggedIn)
            {
                if (Application.internetReachability != NetworkReachability.NotReachable)
                {
                    LootLockerSDKManager.StartGuestSession(response =>
                    {
                        if (response.success)
                        {
                            Debug.Log("Đăng nhập lại LootLocker thành công!");
                            Login();
                            isLoggedIn = true;
                        }
                        else
                        {
                            Debug.LogWarning("LootLocker vẫn chưa đăng nhập được.");
                            isLoggedIn = false;
                        }
                    });
                }
            }

            yield return new WaitForSeconds(checkInterval);
        }
    }

    public int GetPlayerID()
    {
        return player_id;
    }
    public string GetPlayerName()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
            return player_name;
        else return "OfflinePlayer";
    }
    public string GetPlayerAvatar()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
            return player_avar;
        else return "0";
    }
    //public void Create(ref LoginSaveData data)
    //{
    //   data.player_id = player_id;
    //}
    //public void Save(ref LoginSaveData data)
    //{
    //    data.player_id = player_id;
    //}
    //[System.Serializable]
    //public struct LoginSaveData
    //{
    //    public int player_id;
    //}

}
