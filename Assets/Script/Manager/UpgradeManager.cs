using NUnit.Framework;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance { get; private set; }
    [SerializeField] private List<UpgradeBaseData> upgradedataList = new();
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
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void LoadUpgradeData()
    {
        upgradedataList.Add(new UpgradeBaseData()
        {
            upgradeType = UpgradeType.Shield,
            duration = 5f,
            price = 100
        });
        upgradedataList.Add(new UpgradeBaseData()
        {
            upgradeType = UpgradeType.X2Coin,
            duration = 5f,
            price = 150
        });
    }
    public void Buy(int index)
    {
        if (index >= Enum.GetValues(typeof(UpgradeType)).Length) return;
        UpgradeType upgradeType = (UpgradeType)index;
        UpgradeBaseData upgradeData = upgradedataList.Find(x => x.upgradeType == upgradeType);
        if (upgradeData != null)
        {
            if (CoinManager.Instance.GetCoin() >= upgradeData.price)
            {
                CoinManager.Instance.RemoveCoin(upgradeData.price);
                ApplyUpgrade(upgradeData);
            }
            else
            {
                Debug.Log("Not enough coins");
            }
        }
    }
    public float GetDuration(int index)
    {
        if (index >= Enum.GetValues(typeof(UpgradeType)).Length) return 0;
        UpgradeType upgradeType = (UpgradeType)index;
        UpgradeBaseData upgradeData = upgradedataList.Find(x => x.upgradeType == upgradeType);
        if (upgradeData != null)
        {
            return upgradeData.duration;
        }
        else
        {
            Debug.Log("Upgrade not found");
            return 0f;
        }
    }
    public int GetPrice(int index)
    {
        if (index >= Enum.GetValues(typeof(UpgradeType)).Length) return 0;
        UpgradeType upgradeType = (UpgradeType)index;
        UpgradeBaseData upgradeData = upgradedataList.Find(x => x.upgradeType == upgradeType);
        if (upgradeData != null)
        {
            return upgradeData.price;
        }
        else
        {
            Debug.Log("Upgrade not found");
            SaveSystem.Save();
            return 0;
        }
    }
    public void ApplyUpgrade(UpgradeBaseData upgradeData)
    {
        upgradeData.duration += 2f;
        upgradeData.price *= 2;
        PowerUp.Instance.SetDuration((int)upgradeData.upgradeType,upgradeData.duration);
        SaveSystem.Save();
    }
    public void LoadInPowerUp()
    {
        for(int i = 0; i < upgradedataList.Count; i++)
        {
            PowerUp.Instance.SetDuration((int)upgradedataList[i].upgradeType, upgradedataList[i].duration);
        }
    }
    
    public void Save(ref UpgradeSaveData data)
    {
        if(upgradedataList.Count > 0)
        {
            data.upgradeDatas = upgradedataList.ToArray();
        }else
        {
            LoadUpgradeData();
            data.upgradeDatas = upgradedataList.ToArray();
        }
    }
    public void Create(ref UpgradeSaveData data)
    {
        upgradedataList.Clear();
        LoadUpgradeData();
        data.upgradeDatas = upgradedataList.ToArray();
    }
    public void Load(UpgradeSaveData data)
    {
        if(data.upgradeDatas == null)
        {
            Debug.Log("No upgrade data found");
            LoadUpgradeData();
            return;
        }else
        upgradedataList = new List<UpgradeBaseData>(data.upgradeDatas); 
        LoadInPowerUp();
    }
    [System.Serializable]
    public struct UpgradeSaveData
    {
        public UpgradeBaseData[] upgradeDatas;
    }
}
[System.Serializable]
public class UpgradeBaseData
{
    public UpgradeType upgradeType;
    public float duration;
    public int price;
}
public enum UpgradeType
{
    Shield,
    X2Coin
}
