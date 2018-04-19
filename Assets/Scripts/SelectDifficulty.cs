using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectDifficulty : MonoBehaviour {

	public GameObject canvasMenuPrincipale;
	public GameObject canvasDifficolta;
	public string gameDifficulty;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	public void EasyButton()
	{
		gameDifficulty = "easy";
		PlayerPrefs.SetString("gameDifficulty", gameDifficulty);
		SceneManager.LoadScene ("SelectCar");
	}

	public void HardButton()
	{
		gameDifficulty = "hard";
		PlayerPrefs.SetString("gameDifficulty", gameDifficulty);
		SceneManager.LoadScene ("SelectCar");
	}

	public void BackButton()
	{
		canvasMenuPrincipale.SetActive(true);
		canvasDifficolta.SetActive (false);
	}
}
