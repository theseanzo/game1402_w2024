using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exhibit2 : Exhibit
{
    [SerializeField]
    Transform carSpawnLocation, animalSpawn;
    [SerializeField]
    KinematicCar carPrefab;
    [SerializeField]
    GameObject animalPrefab;
    [SerializeField]
    float carSpeed = 20f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }
}
