using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private int _score;
    private Food[] _foods;
    private int _numberCollected = 0;
    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            _numberCollected += value >= 0 ? 1 : 0;

            UIManager.Instance.SetScore(_score, _numberCollected, _foods.Length);
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
        _foods = FindObjectsOfType<Food>();
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
