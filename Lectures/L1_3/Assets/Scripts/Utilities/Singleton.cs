using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Should be covered with generics. You could also make this version one that persists between scenes, which I didn't do for this example as we only had one scene.
/// </summary>
/// <typeparam name="T"></typeparam>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour //this line is probably very confusing for students the first time
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
            }
            return _instance;        
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
