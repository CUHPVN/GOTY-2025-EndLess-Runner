using UnityEngine;

public class Pad : MonoBehaviour
{
    private Transform cam;
    [SerializeField] float spawnDistance = 40f;
    [SerializeField] bool isPortal = false;
    private bool spawn=false;
    private void OnEnable()
    {
        spawn = false;
    }
    void Start()
    {
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnByDistance();
    }
    public void SetSpawn(bool spawn)
    {
        this.spawn = spawn;
    }
    public bool GetSpawn()
    {
        return spawn;
    }
    void SpawnByDistance()
    {
        if (cam != null)
        {
            if (!spawn && Vector2.Distance(transform.position, cam.position)<10f)
            {
                if(isPortal)
                {
                    MapSpawner.Instance.SpawnOnceWithPos(transform.position + new Vector3(spawnDistance, 0, 0));
                }
                else
                {
                    MapSpawner.Instance.SpawningWithPos(transform.position + new Vector3(spawnDistance, 0, 0));
                }
                
                spawn=true;
            }
        }
        else
        {
            cam = Camera.main.transform;
        }
    }

}
