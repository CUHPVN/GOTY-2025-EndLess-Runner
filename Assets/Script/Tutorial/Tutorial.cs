using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
        	TransitionManager.Instance.PlayOutInGame();
        }
    }
}