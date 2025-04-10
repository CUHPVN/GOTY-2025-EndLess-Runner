using UnityEngine;

public class ShieldAnimation : MonoBehaviour
{
    public GameObject shield;
    void Update()
    {
        if (!shield.activeSelf && PowerUp.Instance.ShieldActive)
        {
            shield.SetActive(PowerUp.Instance.ShieldActive);
            shield.GetComponent<Animator>().SetBool("Enable",true);
        }
        else if(shield.activeSelf && !PowerUp.Instance.ShieldActive)
        {
            shield.GetComponent<Animator>().SetBool("Enable", false);
            Invoke(nameof(TurnOffShield), 0.5f);
        }
    }
    void TurnOffShield()
    {
        shield.SetActive(false);
    }
}
