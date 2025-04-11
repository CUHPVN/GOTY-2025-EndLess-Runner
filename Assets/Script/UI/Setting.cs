using UnityEngine;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
	
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	
	public void DeleteSave()
	{
		SaveSystem.DeleteSave();
		//SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
