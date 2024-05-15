using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exhibit : MonoBehaviour
{
    protected bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        DeActivate();
    }
    
    protected virtual void Activate()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            
            transform.GetChild(i).gameObject.SetActive(true); //Go through all the children of the exhibit and turn them on
        }
    }
    protected virtual void DeActivate()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            transform.GetChild(i).gameObject.SetActive(false); //Go through and turn them off
        }
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<FirstPersonController>()) //When our player enters an exhibit, we turn the exhibit on by activating its children
        {
            isActive = true;

            Activate();
        }

    }
    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<FirstPersonController>()) //when we exit, we turn the children off 
        {
            isActive = true;

            DeActivate();
        }
    }
}
