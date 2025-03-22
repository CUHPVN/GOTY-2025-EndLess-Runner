using UnityEngine;

public class Pad : MonoBehaviour
{
    private Transform cam;
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
            if (!spawn && Vector2.Distance(transform.position, cam.position)<=1f)
            {
                spawn=true;
            }
        }
        else
        {
            cam = Camera.main.transform;
        }
    }

}
