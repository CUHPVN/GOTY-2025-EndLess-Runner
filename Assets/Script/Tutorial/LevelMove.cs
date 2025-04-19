using UnityEngine;

public class LevelMove : MonoBehaviour
{
	public float LevelMoveSpeed;
    private void FixedUpdate()
    {
		transform.Translate(Vector3.left * LevelMoveSpeed * Time.deltaTime,Space.World);
    }

}
