using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



public class MainMenu : MonoBehaviour {

	//si utilizzano 2 canvas: una per il menu principale, una per scegliere la difficoltà quando si preme su Nuova Partita
	public GameObject canvasMenuPrincipale;
	public GameObject canvasDifficolta;
	public GameObject canvasIstruzioni;

	string modGame;

	//queste variabili vengono utilizzate nel caso si prema su Carica Partita
	string currentScene;
	string currentCar;
	string currentDifficulty;
	string selectedCar;
	string difficulty;
	int level;

	// Use this for initialization
	void Start () {
		modGame = "";
	}
	
	// Update is called once per frame
	void Update () {


	}


	//i prossimi metodi corrispondono alle funzioni dei bottoni cliccabili nel menu principale
	public void NewGame()
	{
		modGame = "newGame";//ogni volta che questa variabile sarà impostata a "newGame" la partita verrà salvata
		level = 1;
		canvasMenuPrincipale.SetActive(false);
		canvasDifficolta.SetActive (true);
		PlayerPrefs.SetString ("modGame", modGame);
		PlayerPrefs.SetInt ("level", level);
	}

	public void LoadGame()
	{
		modGame = "loadGame";

		string destination = Application.persistentDataPath + "/save.dat";
		FileStream file;

		if(File.Exists(destination)) file = File.OpenRead(destination);
		else
		{
			Debug.LogError("File not found");
			return;
		}

		BinaryFormatter bf = new BinaryFormatter();
		GameData data = (GameData) bf.Deserialize(file);
		file.Close();

		//ci si recupera i dati dall'ultimo salvataggio e, attraverso il PlayerPrefs, li si settano per poter essere utilizzati nella scena successiva
		currentScene = data.scene;
		currentCar = data.car;
		currentDifficulty = data.difficulty;
		level = data.level;

		selectedCar = currentCar;
		difficulty = currentDifficulty;
		PlayerPrefs.SetString ("selectedCar", selectedCar);
		PlayerPrefs.SetString ("gameDifficulty", difficulty);
		PlayerPrefs.SetString ("modGame", modGame);
		PlayerPrefs.SetInt ("level", level);
		SceneManager.LoadScene (currentScene);
	}

	public void Instructions()
	{
		canvasMenuPrincipale.SetActive(false);
		canvasIstruzioni.SetActive (true);
	}

	public void QuitGame()
	{
		Debug.Log ("Uscendo dal gioco...");
		Application.Quit();
	}
}
