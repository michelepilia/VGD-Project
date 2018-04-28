using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//ci si arriva dal menu principale, quando si clicca su Nuova Partita
public class Instructions : MonoBehaviour {

	public GameObject canvasMenuPrincipale;
	public GameObject canvasIstruzioni;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}



	public void BackButton()
	{
		canvasMenuPrincipale.SetActive(true);
		canvasIstruzioni.SetActive (false);
	}
}
