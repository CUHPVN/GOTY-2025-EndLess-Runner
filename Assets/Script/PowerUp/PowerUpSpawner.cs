using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
	
	[Range(0.0f,1.0f)] public float SpawnPercentage;
	float Percentage;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	private void OnEnable()
	{
		Percentage = Random.Range(0.0f,1.0f);
		if(Percentage < 1f - SpawnPercentage)
		{
			transform.gameObject.SetActive(false);
		}
	}
}
