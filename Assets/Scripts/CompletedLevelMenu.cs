using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//script che viene lanciato al completamento di ogni livello
public class CompletedLevelMenu : MonoBehaviour {

	public int level;
	string modGame;
	public Text completedLevel;
	public Text unlockedCar;
	public GameObject NextLevelButton;


	// Use this for initialization
	void Start () {
		level = PlayerPrefs.GetInt ("level");//ci si recupera il numero del livello, in modo da poter essere aggiornato
		unlockedCar.text = "";
		completedLevel.text = "";
		}
	
	// Update is called once per frame
	void Update () {
		if (level < 6) {
			unlockedCar.text = "** Nuova auto sbloccata! **";
			completedLevel.text = "Livello completato!";
		} else {
			unlockedCar.text = "";
			NextLevelButton.SetActive (false);
			completedLevel.text = "Complimenti! Hai completato il gioco";
		}
		
	}


	//i prossimi 4 metodi corrispondono alle funzioni dei bottoni cliccabili nel menu di livello completato
	public void NextLevel()
	{
		level++;
		modGame = "newGame";//se modGame era impostata a "loadGame", viene reimpostata a "newGame", in modo che all'avvio del prossimo livello, la partita venga salvata
		PlayerPrefs.SetString ("modGame", modGame);
		PlayerPrefs.SetInt ("level", level);
		Time.timeScale = 1f;
		SceneManager.LoadScene ("SelectCar");
	}

	public void LoadMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene ("MainMenu");
	}

	public void Restart()
	{
		AudioListener.pause = false;
		Time.timeScale = 1f;
		Scene restartGame = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (restartGame.buildIndex);
	}

	public void QuitGame()
	{
		Debug.Log ("Uscendo dal gioco...");
		Application.Quit();
	}
}
