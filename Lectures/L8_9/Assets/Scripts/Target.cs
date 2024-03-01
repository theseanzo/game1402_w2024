using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
    public UnityEvent Hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("You hit me");
        if (collision.gameObject.GetComponent<Projectile>())
        {
            Hit?.Invoke();
            Debug.Log("You even hit me with a projectile");
        }
    }
}
