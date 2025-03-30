using UnityEngine;

public class JumpNode : MonoBehaviour
{
	public float Force;
	public bool stay = false;
	
	Rigidbody2D playerrb;

    private void Start()
    {
        playerrb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }


    private void Update()
	{
		if(stay && Input.GetButtonDown("Jump"))
		{
			playerrb.linearVelocity = new Vector2(playerrb.linearVelocity.x, Force);
			stay = false;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Player"))
		{
			stay = true;
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Player"))
		{
			stay = false;
		}
	}

}
