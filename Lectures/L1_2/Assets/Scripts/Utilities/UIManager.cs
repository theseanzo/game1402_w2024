using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    [SerializeField]
    TMP_Text scoreText;
    [SerializeField]
    TMP_Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetScore(int score)
    { 
        this.scoreText.text = string.Format("Score: {0}", score);
    }
    public void SetTime(float time)
    {
        this.timeText.text = string.Format("{0:0}", time);
    }
}
