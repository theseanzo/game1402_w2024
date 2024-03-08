using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveSpawner : MonoBehaviour
{
    #region Serialize Fields
    [SerializeField]
    Transform startPosition, endPosition;
    [SerializeField]
    List<Wave> waves = new List<Wave>();
    #endregion
    #region Public variables
    #endregion
    #region Private variables

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    } 
    public void StartSpawn()
    {
        //this is called when our game begins
        Debug.Log("We started spawning");

    }
}
