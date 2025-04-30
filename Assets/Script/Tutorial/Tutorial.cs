using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private TMP_Text text1;
    [SerializeField] private TMP_Text text2;
    [SerializeField] private TMP_Text text3;
    [SerializeField] private TMP_Text text4;
    private void Start()
    {
        Began();
    }
    public void Began()
    {
#if UNITY_EDITOR || UNITY_STANDALONE

        text1.text = "Press Space or Up Arrow to Jump! Hold it to Jump higher";
        text2.text = "The button performs a different action for each form.";
        text3.text = "Try it";
        text4.text = "Nice! You've finished the tutorial! Have fun playing the game!";

#elif UNITY_ANDROID || UNITY_IOS
        text1.text = "Touch the screen to jump! Hold to jump higher.";
        text2.text = "Each form reacts differently when you touch the screen.";
        text3.text = "Try it";
        text4.text = "Nice! You've finished the tutorial! Have fun playing the game!";
#else
    return;
#endif
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.SetIsFirst();
        	TransitionManager.Instance.PlayOutInGame();
        }
    }
}