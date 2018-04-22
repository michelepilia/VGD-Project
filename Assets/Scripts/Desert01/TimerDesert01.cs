//Riferimenti al link: https://www.youtube.com/watch?v=x-C95TuQtf0

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerDesert01 : MonoBehaviour {

	public int timeLeft;
	public int bonusTime = 10;
	public Text CountdownText;
	public Text BonusTimeText;
	public GameObject GameOverMenu;
	public GameObject CompletedLevelMenu;
	public int totCheckpoints = 7;
	public int passedCheckpoints = 0;
	public string difficulty;

	// Use this for initialization
	void Start () {

		difficulty = PlayerPrefs.GetString("gameDifficulty");

		if(difficulty.Equals("easy"))
		{
			timeLeft = 180;
		}
		else
		{
			timeLeft = 120;
		}

		//parte il countdown
		StartCoroutine("LoseTime");
		
	}
	
	// Update is called once per frame
	void Update () {

		if ((timeLeft % 60) < 10) {
			CountdownText.text = ("" + (timeLeft / 60) + ":0" + (timeLeft % 60));
		} else {
			CountdownText.text = ("" + (timeLeft / 60) + ":" + (timeLeft % 60));
		}
			
		if(timeLeft > 59)
		{
			CountdownText.color = Color.white;
		}

		if(timeLeft <= 59 && timeLeft > 9)
		{
			CountdownText.color = Color.yellow;
		}


		if(timeLeft <= 9)
		{
			CountdownText.color = Color.red;
		}

		//game over
		if(timeLeft < 0)
		{
			StopCoroutine ("LoseTime");
			CountdownText.text = "Tempo Scaduto!";
		}

		if (CountdownText.text.Equals("Tempo Scaduto!")) {
			StartCoroutine ("GameOver");
		}

		//livello completato
		if(timeLeft >= 0 && passedCheckpoints == totCheckpoints)
		{
			StopCoroutine ("LoseTime");
			CountdownText.color = Color.green;
			Debug.Log ("Livello completato");
			StartCoroutine ("CompletedLevel");
		}
		
	}

	IEnumerator LoseTime()
	{
		while (true) 
		{
			yield return new WaitForSeconds (1);
			timeLeft--;
		}
	}

	public void updateTime()
	{
		passedCheckpoints++;
		if (timeLeft >= 0 && passedCheckpoints < totCheckpoints) {
			timeLeft += bonusTime;
			BonusTimeText.text = "+" + bonusTime + " sec";
			StartCoroutine ("AddTime");
		}
	}

	IEnumerator AddTime()
	{
		yield return new WaitForSeconds(2);
		BonusTimeText.text = "";
	}

	IEnumerator GameOver()
	{
		yield return new WaitForSeconds (1);
		GameOverMenu.SetActive (true);
		Time.timeScale = 0f;
		AudioListener.pause = true;
	}

	IEnumerator CompletedLevel()
	{
		yield return new WaitForSeconds (1);
		CompletedLevelMenu.SetActive (true);
		Time.timeScale = 0f;
		AudioListener.pause = true;
	}
		
}
