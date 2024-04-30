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

    /// <summary>
    /// Pretty self-explanatory. Could be nice for showing them formatting
    /// </summary>
    /// <param name="score"></param>
    /// <param name="collected"></param>
    /// <param name="totalItems"></param>
    public void SetScore(int score, int collected, int totalItems)
    { 
        this.scoreText.text = string.Format("Score: {0}\n{1}/{2}", score, collected, totalItems);
    }
    public void SetTime(float time)
    {
        this.timeText.text = string.Format("{0:0}", time);
    }
}
