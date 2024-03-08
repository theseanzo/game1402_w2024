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

    #endregion

    // Update is called on%e per frame
    void Update()
	{
		
	}
    public void StartGame() //when we start the game, we start spawning
    {
        foreach(WaveSpawner spawner in waveSpawners)
        {
            spawner.StartSpawn(); 
        }
	}

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }
    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
    }
    private void FixedUpdate()
    {

    }
}
