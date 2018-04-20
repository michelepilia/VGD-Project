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
	string modGame; //serve a capire se si è avviata una nuova partita e se quindisi deve salvare

	void Start()
	{
		currentScene = SceneManager.GetActiveScene ().name.ToString ();
		currentCar = PlayerPrefs.GetString("selectedCar");
		currentDifficulty = PlayerPrefs.GetString("gameDifficulty");
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

	public void SaveFile()
	{
		string destination = Application.persistentDataPath + "/save.dat";
		FileStream file;

		if(File.Exists(destination)) file = File.OpenWrite(destination);
		else file = File.Create(destination);

		GameData data = new GameData(currentScene, currentCar, currentDifficulty);
		BinaryFormatter bf = new BinaryFormatter();
		bf.Serialize(file, data);
		file.Close();
	}

	public void LoadFile()
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

		SceneManager.LoadScene (currentScene);

		/*Debug.Log(data.scene);
		Debug.Log(data.car);
		Debug.Log(data.difficulty);*/
	}

}