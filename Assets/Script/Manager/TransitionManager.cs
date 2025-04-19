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
        child.transform.position = new(0, 0);
        child.DOMoveX(-50f,1f);
    }
    public void PlayOut()
    {
        child.transform.position = new(50, 0);
        child.DOMoveX(0f,1f);
    }
    public void PlayAgainInGame()
    {
        child.transform.position = new(50,0);
        child.DOMoveX(0f, 1f).OnComplete(() => ChangeAgainScene()).SetUpdate(true);
    }
    public void PlayOutInGame()
    {
        child.transform.position = new(50, 0);
        child.DOMoveX(0f, 1f).OnComplete(()=> ChangeOutScene()).SetUpdate(true);
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
