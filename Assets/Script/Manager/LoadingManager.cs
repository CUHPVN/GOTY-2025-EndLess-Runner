using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    [SerializeField] Image loadfill;
    [SerializeField] float loadTime = 2f;
    [SerializeField] float time=0;
    void Start()
    {
        Invoke(nameof(Out),loadTime-0.5f);
        Invoke(nameof(Load), loadTime);
    }
    void Out()
    {
        TransitionManager.Instance.PlayOut();
    }
    void Load()
    {
        SceneManager.LoadScene("MainMenu");
    }
    void Update()
    {
        time += Time.deltaTime;
        loadfill.fillAmount = time / (loadTime-1f);
    }
}
