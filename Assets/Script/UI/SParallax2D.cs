using UnityEngine;
using UnityEngine.UIElements;

public class SParallax2D : MonoBehaviour
{
	GameObject cam;
	float StartPos;
	float Length;
	float movement;

	public float BGMoveSpeed;
	[SerializeField] float ParallaxEffectSpeed;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		cam = Camera.main.gameObject;
		StartPos = cam.transform.position.x;
		Length = GetComponent<SpriteRenderer>().bounds.size.x;
	}

	// Update is called once per frame
	void Update()
	{
		movement = StartPos - transform.position.x;

		transform.position = new Vector3(transform.position.x + BGMoveSpeed/1000 * ParallaxEffectSpeed, transform.position.y, transform.position.z);
		if (movement > StartPos + Length)
		{
			transform.position = new Vector3(StartPos, transform.position.y, transform.position.z);
		}
		else if (movement < StartPos - Length)
		{
			transform.position = new Vector3(StartPos, transform.position.y, transform.position.z);
		}
	}
}
