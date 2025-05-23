using UnityEngine;

public class ShieldEffect : MonoBehaviour
{
	Animator anim;
	public static ShieldEffect Instance { get; private set; }
	private void Awake()
	{
		Instance = this;
	}
	private void Start()
	{
		anim = GetComponent<Animator>();
	}
	public void StartEffect()
	{
		SoundManager.Instance.PlaySFX((int)SoundManager.SoundType.ShieldBreak);
        anim.SetBool("Explode",true);
	}
	public void StopEffect()
	{
		anim.SetBool("Explode",false);
	}
}
