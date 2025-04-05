using UnityEngine;

public class Coins : MonoBehaviour
{
    private void OnEnable()
    {
        foreach(Transform Coin in transform)
        {
        	if(Coin != null && !Coin.gameObject.activeSelf)
            {
            	Coin.gameObject.SetActive(true);
            }
        }
    }
}
