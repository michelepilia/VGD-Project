using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour {

	public Camera MainCamera;
	public Camera HighCamera;
	GameObject carSignaller;

	// Use this for initialization
	void Start () {

		carSignaller = GameObject.FindGameObjectWithTag ("TargetMap");//segnalino nella camera dall alto	
		MainCamera.enabled = true; //A inizio gioco abilita la camera principale
		HighCamera.enabled = false; //Disattiva quella dall'alto
		carSignaller.SetActive (false); //Disattiva il segnalino 
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.U)) {
			HighCamera.enabled = !HighCamera.enabled; //attivo la high camera, sovrascrivendo la principale (o disattivo)
			carSignaller.SetActive (!(carSignaller.activeSelf)); //Attiva (o disattiva) il segnalino 

		}
	}
}

