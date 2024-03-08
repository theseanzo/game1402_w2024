using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Exhibit3 : Exhibit
{
    #region Serialize Fields

	[SerializeField] private TMP_Text scoreText, timeText;
	[SerializeField] float gameDuration = 30f;
    [SerializeField] List<WaveSpawner> waveSpawners = new List<WaveSpawner>(); //specify the wave spawners in our scene
    #endregion
    #region private variables
    bool gameStarted = false;
    float score = 0; //every time we start the game we will restart the score
    float timeElapsed = 0; //the amount of time that has gone on in our game
    int scoreIncrease = 1; //this could be based on the target but for now...just increase by 1
    #endregion

    // Update is called on%e per frame
    void Update()
	{
		
	}
    public void StartGame() //when we start the game, we start spawning
    {
        if (!gameStarted)
        {
            //reset our settings
            gameStarted = true;
            score = 0;
            timeElapsed = 0;
            foreach (WaveSpawner spawner in waveSpawners)
            {
                spawner.StartSpawn();
                spawner.targetHit.AddListener(() => score += scoreIncrease); //when our target is hit we register an anonymous function that adds to the score
            }
        }
	}
    public void StopGame()
    {
        timeElapsed = gameDuration; //this is public because we may want to call it from multiple places
        gameStarted = false;
        foreach(WaveSpawner spawner in waveSpawners)
        {
            spawner.StopSpawn(); //do not spawn when game is inactive. do not pass go; do not collect 200$
        }
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }
    protected override void OnTriggerExit(Collider other)
    { 
        base.OnTriggerExit(other);
        if (other. GetComponentInParent<FirstPersonController>())
            StopGame();
    }
    private void FixedUpdate()
    {
        if (gameStarted)
            timeElapsed += Time.fixedDeltaTime;
        float timeRemaining = gameDuration - timeElapsed; //display how long the game has been going
        timeText.text = string.Format("{0:00.00}", timeRemaining <= 0f ? 0f : timeRemaining );
        scoreText.text = string.Format("{0:0000}", score);
        if (timeRemaining < 0)
            StopGame();
    }
}
