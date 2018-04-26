//Riferimento al link: https://www.youtube.com/watch?v=JivuXdrIHK0

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//menu di pausa, che verrà lanciato ogni qualvolta in gioco si prema esc
public class PauseMenu : MonoBehaviour {

	public static bool GameIsPaused = false;

	public GameObject pauseMenuUI;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if (GameIsPaused) {
				Resume ();
			} else {
				Pause ();
			}
		}
	}

	public void Resume()
	{
		pauseMenuUI.SetActive (false);
		Time.timeScale = 1f;
		GameIsPaused = false;
		AudioListener.pause = false;
	}

	void Pause()
	{
		pauseMenuUI.SetActive (true);
		Time.timeScale = 0f;
		GameIsPaused = true;
		AudioListener.pause = true;
	}

	public void LoadMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene ("MainMenu");
	}

	public void Restart()
	{
		Resume ();
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
