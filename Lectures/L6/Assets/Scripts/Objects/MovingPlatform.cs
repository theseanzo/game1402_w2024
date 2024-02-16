using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
	#region Serialize Fields
	[SerializeField]
	Transform[] wayPoints;
	[SerializeField]
	float speed=5f;
	#endregion
	#region Private variables for moving
	int currentTargetPosition = 0;
	int nextTargetPosition = 1;
	float minTargetDistance = 0.01f;
	
	#endregion
	// Start is called before the first frame update
	void Start()
	{
		
	}


	// Update is called once per frame
	void Update()
	{

	}

}
