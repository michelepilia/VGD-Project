using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletedLevelMenu : MonoBehaviour {

	public int level;


	// Use this for initialization
	void Start () {
		level = PlayerPrefs.GetInt ("level");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void NextLevel()
	{
		level++;
		PlayerPrefs.SetInt ("level", level);
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
