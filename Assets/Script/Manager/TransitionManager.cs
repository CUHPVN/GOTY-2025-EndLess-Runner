using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public static TransitionManager Instance { get; private set; }
    [SerializeField] private Transform child;
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        //DontDestroyOnLoad(this);
    }
    private void Start()
    {
        child = GameObject.FindGameObjectWithTag("Trans").transform;
    }
    public void PlayIn()
    {
        if (child == null)
        {
            child = GameObject.FindGameObjectWithTag("Trans").transform;
        }
        child.DOMoveX(0f, 0f);
        child.DOMoveX(-50f,0.5f);
    }
    public void PlayOut()
    {
        if (child == null)
        {
            child = GameObject.FindGameObjectWithTag("Trans").transform;
        }
        child.DOMoveX(50f,0f);
        child.DOMoveX(0f,0.5f);
    }
    public void PlayAgainInGame()
    {
        if (child == null)
        {
            child = GameObject.FindGameObjectWithTag("Trans").transform;
        }
        child.DOMoveX(50f, 0f).SetUpdate(true);
        child.DOMoveX(0f, 0.5f).OnComplete(() => ChangeAgainScene()).SetUpdate(true);
    }
    public void PlayOutInGame()
    {
        if (child == null)
        {
            child = GameObject.FindGameObjectWithTag("Trans").transform;
        }
        child.DOMoveX(50f, 0f).SetUpdate(true);
        child.DOMoveX(0f, 0.5f).OnComplete(()=> ChangeOutScene()).SetUpdate(true);
    }
    public void ChangeOutScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ChangeAgainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
    void Update()
    {
        if(child == null)
        {
            child = GameObject.FindGameObjectWithTag("Trans").transform;
        }
    }
}
