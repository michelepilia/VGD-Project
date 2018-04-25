using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToTheLastCheckpoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Space))
		{
			GameObject.FindGameObjectWithTag("Car").SendMessage("RepositionDesertCheckpoint");
		}
		
	}

}
