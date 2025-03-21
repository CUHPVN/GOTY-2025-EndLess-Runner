using UnityEngine;

public class Pad : MonoBehaviour
{
    private Transform cam;
    [SerializeField] float spawnDistance = 40f;
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
    void SpawnByDistance()
    {
        if (cam != null)
        {
            if (!spawn && Vector2.Distance(transform.position, cam.position)<10f)
            {
                MapSpawner.Instance.SpawningWithPos(transform.position + new Vector3(spawnDistance,0,0));
                spawn=true;
            }
        }
        else
        {
            cam = Camera.main.transform;
        }
    }

}
