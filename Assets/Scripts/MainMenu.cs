using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



public class MainMenu : MonoBehaviour {

	public GameObject canvasMenuPrincipale;
	public GameObject canvasDifficolta;
	string modGame;
	string currentScene;
	string currentCar;
	string currentDifficulty;
	string selectedCar;
	string difficulty;

	// Use this for initialization
	void Start () {
		modGame = "";
	}
	
	// Update is called once per frame
	void Update () {


	}



	public void NewGame()
	{
		modGame = "newGame";
		canvasMenuPrincipale.SetActive(false);
		canvasDifficolta.SetActive (true);
		PlayerPrefs.SetString ("modGame", modGame);
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

		currentScene = data.scene;
		currentCar = data.car;
		currentDifficulty = data.difficulty;

		selectedCar = currentCar;
		difficulty = currentDifficulty;
		PlayerPrefs.SetString ("selectedCar", selectedCar);
		PlayerPrefs.SetString ("gameDifficulty", difficulty);
		PlayerPrefs.SetString ("modGame", modGame);
		SceneManager.LoadScene (currentScene);
	}

	public void QuitGame()
	{
		Debug.Log ("Uscendo dal gioco...");
		Application.Quit();
	}
}
