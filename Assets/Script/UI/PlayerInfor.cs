using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfor : MonoBehaviour
{
    public static PlayerInfor Instance {  get; private set; }
    [SerializeField] private TMP_InputField playerName;
    [SerializeField] private Transform avatarParent;
    [SerializeField] private Transform ignoreTarget;
    [SerializeField] private GameObject frameParent;
    [SerializeField] private List<Image> avatarList;
    [SerializeField] private List<Image> frameList;
    [SerializeField] private List<Button> buttonAvatarList;
    [SerializeField] private List<Button> buttonFrameList;
    [SerializeField] private List<Sprite> spriteAvatarList;
    [SerializeField] private List<Sprite> spriteFrameList;
    
    //[SerializeField] private int frameInx = 0;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        LoadAvatar();
    }
    private void OnEnable()
    {
        playerName.text = GameManager.Instance.GetName();
        ignoreTarget.gameObject.SetActive(false);
    }
    void Update()
    {
    }
    
    public void LoadAvatar()
    {
        int index = 0;
        foreach(Transform item in avatarParent)
        {
            if (index >= spriteAvatarList.Count) return;
            item.GetComponent<Image>().sprite = spriteAvatarList[index];
            buttonAvatarList.Add(item.GetComponent<Button>());
            avatarList.Add(item.GetComponent<Image>());
            index++;
        }
        for(int i =0;i< buttonAvatarList.Count;i++)
        {
            int ind = i;
            buttonAvatarList[i].onClick.AddListener(()=>SetAva(ind));
            buttonAvatarList[i].onClick.AddListener(() => ClosePanel());
        }
    }
    public void ClosePanel()
    {
        ignoreTarget.gameObject.SetActive(true);
        GetComponent<PopOnEnable>().DisableThis();
    }
    private void SetAva(int value)
    {
        if(value >= buttonAvatarList.Count) return;
        GameManager.Instance.SendAvar(value);
    }
    public void ApplyName()
    {
        ClosePanel();
        StartCoroutine(SetName());
    }
    IEnumerator SetName()
    {
        GameManager.Instance.SendName(playerName.text);
        yield return null;
    }
}
