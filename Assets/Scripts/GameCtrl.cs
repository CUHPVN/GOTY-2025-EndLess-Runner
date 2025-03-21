using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : OOPMono
{
    private static GameCtrl instance;   
    public static GameCtrl Instance {  get { return instance; } }

    [SerializeField] protected Camera mainCamera;

    public Camera MainCamera { get { return mainCamera; } }
    [SerializeField] protected Transform player;

    public Transform Player { get { return player; } }
    protected override void Awake()
    {
        base.Awake();
        if (GameCtrl.instance != null) Debug.LogError("Only 1 GameCtrl allow to exit");
        GameCtrl.instance = this;

    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCamera();
        this.LoadPlayer();
    }

    protected virtual void LoadCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = GameCtrl.FindObjectOfType<Camera>(); 
        Debug.Log(transform.name + ": LoadCamera", gameObject);

    }
    protected virtual void LoadPlayer()
    {
        if (this.player != null) return;
        this.player = transform.parent.GetChild(1);
        Debug.Log(transform.name + ": LoadPlayer", gameObject);
    }
}
