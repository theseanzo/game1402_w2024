using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private int _score;
    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            UIManager.Instance.SetScore(_score);
        }
    }
    public float GameTime
    {
        get; private set;
    }
    // Start is called before the first frame update
    void Start()
    {
        GameTime = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        GameTime += Time.deltaTime;
    }
    private void FixedUpdate()
    {
        UIManager.Instance.SetTime(GameTime);
    }
}
