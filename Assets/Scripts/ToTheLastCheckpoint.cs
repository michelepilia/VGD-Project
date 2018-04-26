using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToTheLastCheckpoint : MonoBehaviour {

	string currentScene;

	// Use this for initialization
	void Start () {

		currentScene = SceneManager.GetActiveScene ().name.ToString ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Space))
		{
			switch (currentScene) {
			case "Desert":
				GameObject.FindGameObjectWithTag ("Car").SendMessage ("RepositionDesertCheckpoint");
				break;
			case "Forest":
				GameObject.FindGameObjectWithTag ("Car").SendMessage ("RepositionForestCheckpoint");
				break;
			}
		}
		
	}

}
