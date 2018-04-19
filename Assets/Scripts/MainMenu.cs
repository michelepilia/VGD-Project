using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour {

	public GameObject canvasMenuPrincipale;
	public GameObject canvasDifficolta;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {


	}



	public void NewGame()
	{
		canvasMenuPrincipale.SetActive(false);
		canvasDifficolta.SetActive (true);
	}

	public void QuitGame()
	{
		Debug.Log ("Uscendo dal gioco...");
		Application.Quit();
	}
}
