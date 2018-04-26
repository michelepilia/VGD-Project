//Riferimenti al link: https://www.youtube.com/watch?v=x-C95TuQtf0

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerDesert : MonoBehaviour {

	public int timeLeft;//tempo a disposizione all'avio del livello
	public int bonusTime = 10;//i secondi che si acquisiscono al superamento di ogni checkpoint
	public Text CountdownText;//il timer mostrato nell'interfaccia di gioco
	public Text BonusTimeText;
	public GameObject GameOverMenu;//il menu che viene lanciato se non si riesce a completare il livello entro il tempo a disposizione
	public GameObject CompletedLevelMenu;//il menu che si avvia al completamento del livello
	public int totCheckpoints = 7;
	public int passedCheckpoints = 0;
	public string difficulty;
	int actualTime;//variabile che viene utilizzata per aggiornare il tempo quando si usa il riposizionamento manuale

	// Use this for initialization
	void Start () {

		difficulty = PlayerPrefs.GetString("gameDifficulty");//ci si recupera la difficoltà scelta nel menu principale
		actualTime = timeLeft;

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


		/*Qui viene gestito il timer, dal colore da mostrare in base ai secondi restanti (giallo gli ultimi 59, rosso gli ultimi 9), ai menu da lanciare in caso di compimento
		  o fallimento della missione*/
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

	//metodo chiamato dallo script dei checkpoint per aggiornare il timer con l'aggiunta dei secondi bonus
	public void updateTime()
	{
		passedCheckpoints++;
		if (timeLeft >= 0 && passedCheckpoints < totCheckpoints) {
			timeLeft += bonusTime;
			actualTime = timeLeft;
			//PlayerPrefs.SetInt ("actualTime", actualTime);
			BonusTimeText.text = "+" + bonusTime + " sec";
			StartCoroutine ("AddTime");
		}
	}

	//chiamato dallo script dei checkpoint quando si usa il riposizionamento, serve a riportare il tempo a quello del momento in cui si è superato l'ultimo checkpoint
	public void updateTimeByReposition()
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
