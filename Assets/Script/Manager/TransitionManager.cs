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
        child.transform.position = new(0, 0,0f);
        child.DOMoveX(-50f,1f).SetUpdate(true);
    }
    public void PlayOut()
    {
        child.transform.position = new(50, 0,0f);
        child.DOMoveX(0f,1f).SetUpdate(true);
    }
    public void PlayOutInLoading()
    {
        child.transform.position = new(50, 0, 0);
        child.DOMoveX(0,1f).OnComplete(()=> SceneManager.LoadScene("MainMenu")).SetUpdate(true);
    }
    public void PlayAgainInGame()
    {
        child.transform.position = new(50,0,0f);
        child.DOMoveX(0f, 1f).OnComplete(() => ChangeAgainScene()).SetUpdate(true);
    }
    public void PlayOutInGame()
    {
        child.transform.position = new(50, 0, 0f);
        child.DOMoveX(0f, 1f).OnComplete(()=> ChangeOutScene()).SetUpdate(true);
    }
    public void ChangeOutScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ChangeAgainScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Update()
    {
        if(child == null)
        {
            child = GameObject.FindGameObjectWithTag("Trans").transform;
        }
    }
}
