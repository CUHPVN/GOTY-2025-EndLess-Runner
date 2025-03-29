using Unity.VisualScripting;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
	public float Force;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
		{
			collision.gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(collision.gameObject.GetComponent<Rigidbody2D>().linearVelocity.x, Force);
		}
    }
}
