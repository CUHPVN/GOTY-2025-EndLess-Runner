using UnityEngine;
using System.Collections.Generic;
public class Coins : MonoBehaviour
{
    // Cache the children to avoid repeated transform access
    private List<Transform> cachedCoins;
    
    private void Awake()
    {
        // Cache all children once during initialization
        CacheCoins();
    }
    
    private void CacheCoins()
    {
        cachedCoins = new List<Transform>(transform.childCount);
        for (int i = 0; i < transform.childCount; i++)
        {
            cachedCoins.Add(transform.GetChild(i));
        }
    }
    
    private void OnEnable()
    {
        // If the cache is null or count doesn't match (children were added/removed), rebuild it
        if (cachedCoins == null || cachedCoins.Count != transform.childCount)
        {
            CacheCoins();
        }
        
        // Use a standard for loop with direct indexing (more efficient than foreach)
        for (int i = 0; i < cachedCoins.Count; i++)
        {
            Transform coin = cachedCoins[i];
            if (coin != null && !coin.gameObject.activeSelf)
            {
                coin.gameObject.SetActive(true);
            }
        }
    }
}
