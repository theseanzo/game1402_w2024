using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class WaveTarget : MonoBehaviour
{
    #region Serialize fields

 
    #endregion
    #region Public variables

    #endregion
    #region private variables
    Rigidbody _rb;
    #endregion
    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame

    private void FixedUpdate()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
    }
    private void Death()
    {
        Destroy(this.gameObject);
    }
}
