using System;
using UnityEngine;

public class TempFile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Func<float,float,float> mathFunc = (someX, someY) => someX + someY;
        float z = mathFunc(5.0f, 2.0f);
        mathFunc = (someX, someY) => someX - someY;
        mathFunc = (someX, someY) => someX * someY;
        mathFunc += (someX, someY) => someX / someY;
    }
    
}
