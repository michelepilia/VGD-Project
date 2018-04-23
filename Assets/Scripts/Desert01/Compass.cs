using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour {

	public Vector3 NorthDirection;
	public Transform Player;
	public Quaternion MissionDirection;

	//public RectTransform NorthLayer;
	public RectTransform MissionLayer;

	public Transform missionplace;

	// Use this for initialization
	void Start () {
		missionplace = GameObject.Find ("Checkpoint01").transform;
	}
	
	// Update is called once per frame
	void Update () {
		missionplace = GameObject.FindWithTag ("active_checkpoint").transform;
		ChangeNorthDirection ();
		ChangeMissionDirection();
		
	}



	void ChangeNorthDirection () {
		NorthDirection.z = Player.eulerAngles.y;
		//NorthLayer.localEulerAngles = NorthDirection;
	
	}


	void ChangeMissionDirection() {
		Vector3 dir = transform.position - missionplace.position;

		MissionDirection = Quaternion.LookRotation (dir);

		MissionDirection.z = -MissionDirection.y;
		MissionDirection.y = 0;
		MissionDirection.x = 0;

		MissionLayer.localRotation = MissionDirection * Quaternion.Euler (NorthDirection);    
	}
}
