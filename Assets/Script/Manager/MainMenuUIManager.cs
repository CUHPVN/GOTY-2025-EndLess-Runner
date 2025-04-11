using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUIManager : MonoBehaviour
{
    public static MainMenuUIManager Instance { get; private set; }
    [SerializeField] private Transform shopParent;
    [SerializeField] private TMP_Text coinCount;
    [SerializeField] private List<Transform> upgradeList = new();
    [SerializeField] private List<TMP_Text> titleUpgradeList = new();
    [SerializeField] private List<Button> buttonUpgradeList = new();
    [SerializeField] private List<TMP_Text> priceUpgradeList = new();
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
    }
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
