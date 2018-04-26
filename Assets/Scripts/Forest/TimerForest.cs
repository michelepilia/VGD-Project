using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerForest : MonoBehaviour {

	public int timeLeft;
	public int bonusTime;
	public Text CountdownText;
	public Text BonusTimeText;
	public GameObject GameOverMenu;
	public GameObject CompletedLevelMenu;
	public int totCheckpoints;
	public int passedCheckpoints;
	public string difficulty;
	int level;
	int actualTime;

	// Use this for initialization
	void Start () {

		level = PlayerPrefs.GetInt ("level");
		difficulty = PlayerPrefs.GetString("gameDifficulty");

		switch (level) {
		case 2:
			bonusTime = 15;
			totCheckpoints = 6;
			passedCheckpoints = 0;

			if(difficulty.Equals("easy")){
				timeLeft = 420;
			}
			else{
				timeLeft = 300;
			}

			actualTime = timeLeft;
			break;

		
		case 3:
			bonusTime = 20;
			totCheckpoints = 3;
			passedCheckpoints = 0;

			if(difficulty.Equals("easy")){
				timeLeft = 400;
			}
			else{
				timeLeft = 250;
			}

			actualTime = timeLeft;
			break;
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

	public void updateTimeForest()
	{
		passedCheckpoints++;
		if (timeLeft >= 0 && passedCheckpoints < totCheckpoints) {
			timeLeft += bonusTime;
			actualTime = timeLeft;
			BonusTimeText.text = "+" + bonusTime + " sec";
			StartCoroutine ("AddTime");
		}
	}

	public void updateTimeByRepositionForest()
	{
		timeLeft = actualTime;
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
