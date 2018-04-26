using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveGame : MonoBehaviour {
	string currentScene;
	string currentCar;
	string currentDifficulty;
	string modGame; //serve a capire se si è avviata una nuova partita e se quindi si deve salvare. serve ad evitare un loop infinito di salvataggi
	int currentLevel;

	void Start()
	{
		/*Le prossime 4 variabili corrispondono ai dati di gioco che si vogliono salvare. La quinta è una variabile
		  che serve a capire se si è già salvato o se si deve salvare la partita*/
		currentScene = SceneManager.GetActiveScene ().name.ToString ();
		currentCar = PlayerPrefs.GetString("selectedCar");
		currentDifficulty = PlayerPrefs.GetString("gameDifficulty");
		currentLevel = PlayerPrefs.GetInt ("level");
		modGame = PlayerPrefs.GetString ("modGame");
	}

	void Update()
	{
		if (modGame.Equals ("newGame")) {
			SaveFile ();
			Debug.Log("Partita Salvata!");
			modGame = "";
		}
	}

	//metodo di salvataggio su file
	public void SaveFile()
	{
		string destination = Application.persistentDataPath + "/save.dat";
		FileStream file;

		if(File.Exists(destination)) file = File.OpenWrite(destination);
		else file = File.Create(destination);

		//GameData è una classe da noi creata che serve a contenere i dati di gioco da salvare e da caricare
		GameData data = new GameData(currentScene, currentCar, currentDifficulty, currentLevel);
		BinaryFormatter bf = new BinaryFormatter();
		bf.Serialize(file, data);
		file.Close();
	}

	/*public void LoadFile()
	{
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
		currentLevel = data.level;

		SceneManager.LoadScene (currentScene);

	}*/

}