using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//script che riposiziona la macchina del giocatore alla posizione dell'ultimo checkpoint superato
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
			RepositionCurrentScene ();
		}
		
	}
		


	void RepositionCurrentScene()
	{	
		switch (currentScene) {
		case "Desert":
			GameObject.FindGameObjectWithTag ("Car").SendMessage ("RepositionDesertCheckpoint");
			break;
		case "Forest":
			GameObject.FindGameObjectWithTag ("Car").SendMessage ("RepositionForestCheckpoint");
			break;
		case "Desert2":
			GameObject.FindGameObjectWithTag ("Car").SendMessage ("RepositionDesert2Checkpoint");
			break;
		}
	}

}
