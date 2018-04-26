using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//script che viene lanciato quando non si riesce a completare il livello entro il tempo a disposizione
public class GameOverMenu : MonoBehaviour {
	
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

		
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
