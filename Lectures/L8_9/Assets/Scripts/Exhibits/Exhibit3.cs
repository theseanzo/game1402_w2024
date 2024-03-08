 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Exhibit3 : Exhibit
{
    #region Serialize Fields

	[SerializeField] private TMP_Text scoreText, timeText;
	[SerializeField] float gameDuration = 30f;
    #endregion
    #region private variables

    #endregion

    // Update is called on%e per frame
    void Update()
	{
		
	}
    public void StartGame()
    {

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
