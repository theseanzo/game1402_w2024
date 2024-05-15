using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Explosion : PoolObject
{
    [SerializeField]
    float _timeActive = 2f;
    // Start is called before the first frame update
    public void OnEnable()
    {
        Invoke("OnDeSpawn", _timeActive);
    }

}
