using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour {

	public Vector3 NorthDirection;
	public Transform Player;
	public Quaternion MissionDirection;

	public RectTransform NorthLayer;
	public RectTransform MissionLayer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ChangeNorthDirection ();
		ChangeMissionDirection();
		
	}



	void ChangeNorthDirection () {
		NorthDirection.z = Player.eulerAngles.y;
	
	}


	void ChangeMissionDirection() {



	}
}
