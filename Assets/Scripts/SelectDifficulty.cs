using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//ci si arriva dal menu principale, quando si clicca su Nuova Partita
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



	/*i prossimi 3 metodi corrispondono ai bottoni cliccabili che vengono mostrati quando si è cliccato su Nuova Partita:
	  con i primi 2 si sceglie la difficoltà e si viene rimandati alla scena successiva, con l'ultimo si torna alla schermata
	  precedente*/
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
