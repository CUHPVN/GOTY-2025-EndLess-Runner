using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MainMenuUIManager : MonoBehaviour
{
    public static MainMenuUIManager Instance { get; private set; }
    [SerializeField] private Transform shopParent;
    [SerializeField] private Transform setting;
    [SerializeField] private TMP_Text coinCount;
    [SerializeField] private TMP_Text playerName;
    [SerializeField] private TMP_Text coinCount2;
    [SerializeField] private Slider bgmVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;
    [SerializeField] private List<Transform> upgradeList = new();
    [SerializeField] private List<TMP_Text> titleUpgradeList = new();
    [SerializeField] private List<Button> buttonUpgradeList = new();
    [SerializeField] private List<TMP_Text> priceUpgradeList = new();
    [SerializeField] private List<Button> buttons;

    private void Awake()
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
        LoadUpgrade();
        LoadTitleUpgrade();
        LoadButtonUpgrade();
        AddButtonEvent();
        AddEvent();
        LoadPriceUpgrade();
    }
    public void LoadUpgrade()
    {
        foreach (Transform upgrade in shopParent)
        {
            upgradeList.Add(upgrade);
        }
    }
    public void LoadButtonUpgrade()
    {
        foreach (Transform buttonUpgrade in upgradeList)
        {
            buttonUpgradeList.Add(buttonUpgrade.GetComponentInChildren<Button>());
        }
    }
    public void LoadTitleUpgrade()
    {
        foreach (Transform titleUpgrade in upgradeList)
        {
            titleUpgradeList.Add(titleUpgrade.GetComponentInChildren<TMP_Text>());
        }
    }
    public void LoadPriceUpgrade()
    {
        foreach (Button priceUpgrade in buttonUpgradeList)
        {
            priceUpgradeList.Add(priceUpgrade.GetComponentInChildren<TMP_Text>());
        }
    }
    public void AddButtonEvent()
    {
        for (int i = 0; i < buttonUpgradeList.Count; i++)
        {
            int index = i;
            buttonUpgradeList[i].onClick.AddListener(() => UpgradeManager.Instance.Buy(index));
            buttonUpgradeList[i].onClick.AddListener(() => SoundManager.Instance.PlaySFX((int)SoundManager.SoundType.ButtonClick));
        }
    }
    private void AddEvent()
    {
        foreach (Button but in buttons)
        {
            but.onClick.AddListener(() => SoundManager.Instance.PlaySFX((int)SoundManager.SoundType.ButtonClick));
        }
    }
    public void TitleUpdate()
    {
        for (int i = 0; i < titleUpgradeList.Count; i++)
        {
            titleUpgradeList[i].text = "Duration: "+UpgradeManager.Instance.GetDuration(i);
        }
    }
    public void PriceUpdate()
    {
        for (int i = 0; i < priceUpgradeList.Count; i++)
        {
            priceUpgradeList[i].text = "" + UpgradeManager.Instance.GetPrice(i);
        }
    }
    public void CoinUpdate()
    {
        coinCount.text = ""+CoinManager.Instance.GetCoin();
        coinCount2.text = "" + CoinManager.Instance.GetCoin();
    }
    public void PlayerUpdate()
    {
        playerName.text = GameManager.Instance.GetName();
    }
    public void Update()
    {
        if(priceUpgradeList.Count >0)
        {
            PriceUpdate();
        }
        if(titleUpgradeList.Count >0)
        {
            TitleUpdate();
        }
        CoinUpdate();
        PlayerUpdate();
    }
    public void Start()
    {
        Invoke(nameof(PlayIn), 0f);
        LearderBoard.Instance.Get();
        if(LoginSystem.Instance!=null)
        LearderBoard.Instance.GetHightScore(""+LoginSystem.Instance.GetPlayerID());
    }
    public void PlayIn()
    {
        TransitionManager.Instance.PlayIn();
    }
    public void StartGame()
    {
        TransitionManager.Instance.PlayOut();
        if(!GameManager.Instance.GetIsFirst())
        Invoke(nameof(StartReal), 1f);
        else
        {
            Invoke(nameof(StartTutorialReal), 1f);
        }
    }
    public void StartReal()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void StartTutorialReal()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void SaveGame()
    {
        SaveSystem.Save();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public bool GetSetting()
    {
        return setting.gameObject.activeSelf;
    }
    public void SetVomume(float bgmVolume, float sfxVolume)
    {
        bgmVolumeSlider.value = bgmVolume;
        sfxVolumeSlider.value = sfxVolume;
    }
    public (float v1 ,float v2) GetVolume()
    {
        return (bgmVolumeSlider.value, sfxVolumeSlider.value);
    }
}
