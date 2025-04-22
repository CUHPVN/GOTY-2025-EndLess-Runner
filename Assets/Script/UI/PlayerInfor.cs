using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfor : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerName;
    void Start()
    {
        
    }
    private void OnEnable()
    {
        playerName.text = GameManager.Instance.GetName();
    }
    void Update()
    {
        
    }
    public void SetName()
    {
        GameManager.Instance.SendName(playerName.text);
    }
}
