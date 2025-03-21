using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public abstract class OOPMono : MonoBehaviour
{

    protected virtual void Awake()

    {
        this.LoadComponents();
    }
    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    }

    protected virtual void LoadComponents()
    {
 
    }

    protected virtual void Start()
    {
        
    }

    protected virtual void ResetValue()
    {

    }
    
}

