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

    // Update is called once per frame
    void Update()
    {
        
    }
    protected virtual void Activate()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    protected virtual void DeActivate()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<FirstPersonController>())
        {
            isActive = true;

            Activate();
        }

    }
    protected void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<FirstPersonController>())
        {
            isActive = true;

            DeActivate();
        }
    }
}
